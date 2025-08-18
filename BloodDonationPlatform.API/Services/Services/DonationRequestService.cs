using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class DonationRequestService : IDonationRequestService
{
    private readonly BloodDonationDbContext _context;
    private readonly IMapper _mapper;

    public DonationRequestService(BloodDonationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // إنشاء طلب جديد وإرساله للمتبرعين المؤهلين
    public async Task<int> CreateDonationRequestAsync(CreateDonationRequestDTO dto)
    {
        if (dto.NumOfLiter <= 0)
            throw new ArgumentException("Cannot create a request with zero quantity");
        var request = _mapper.Map<DonationRequest>(dto);
        request.CreatedAt = DateTime.UtcNow;
        request.StatesRequest = StatesRequest.Pending;

        _context.DonationRequests.Add(request);
        await _context.SaveChangesAsync();

        // لو الكمية المطلوبة صفر، لا ترسل للمتبرعين
        if (request.NumOfLiter <= 0)
            return request.Id;

        var hospitalAreaId = await _context.Hospitals
            .Where(h => h.Id == dto.HospitalId)
            .Select(h => h.AreaId)
            .FirstOrDefaultAsync();

        var eligibleDonors = await _context.Donors
            .Where(d => d.BloodTypeId == dto.BloodTypeId &&
                        d.AreaId == hospitalAreaId &&
                        d.DonationRequests.All(dr => dr.LastDateOfDonation <= DateTime.UtcNow.AddMonths(-3)))
            .ToListAsync();

        foreach (var donor in eligibleDonors)
        {
            _context.DonorDonationRequests.Add(new DonorDonationRequest
            {
                DonorId = donor.Id,
                DonationRequestId = request.Id,
                DonorApprovalStatus = null
            });
        }

        await _context.SaveChangesAsync();
        return request.Id;
    }

    // موافقة المتبرع على الطلب
    public async Task<bool> ApproveRequestAsync(DonorActionDto dto)
    {
        var donorRequest = await _context.DonorDonationRequests
            .Include(dr => dr.DonationRequest)
            .FirstOrDefaultAsync(dr => dr.DonorId == dto.DonorId && dr.DonationRequestId == dto.RequestId);

        if (donorRequest == null)
            return false;

        var request = donorRequest.DonationRequest;

        if (request.StatesRequest == StatesRequest.Completed || request.NumOfLiter <= 0)
            return false;

        if (donorRequest.DonorApprovalStatus == true)
            return false;

        donorRequest.DonorApprovalStatus = true;
        donorRequest.LastDateOfDonation = DateTime.UtcNow;

        request.NumOfLiter -= 1;

        if (request.NumOfLiter <= 0)
            request.StatesRequest = StatesRequest.Completed;

        await _context.SaveChangesAsync();
        return true;
    }

    // رفض المتبرع للطلب
    public async Task<bool> RejectRequestAsync(DonorActionDto dto)
    {
        var donorRequest = await _context.DonorDonationRequests
            .FirstOrDefaultAsync(dr => dr.DonorId == dto.DonorId && dr.DonationRequestId == dto.RequestId);

        if (donorRequest != null)
        {
            _context.DonorDonationRequests.Remove(donorRequest);
            await _context.SaveChangesAsync();
        }

        return true;
    }

    // عرض الطلبات في Dashboard المستشفى
    public async Task<List<RequestDashboardDto>> GetDashboardRequestsAsync()
    {
        var requests = await _context.DonationRequests
            .Include(r => r.BloodType)
            .ToListAsync();

        return _mapper.Map<List<RequestDashboardDto>>(requests);
    }
}
