using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Doner;
using Microsoft.EntityFrameworkCore;
using BloodDonationPlatform.API.Services.Interfaces;
using System;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

public class DonorService : IDonorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DonorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<GetDonorDto?> GetDonorByIdAsync(int donorId)
    {
        var donor = await _unitOfWork.DonorRepository.GetByIdAsync(donorId);
        return donor == null ? null : _mapper.Map<GetDonorDto>(donor);
    }

    //public async Task<List<RequestDashboardDto>> GetRequestsForDonorAsync(int donorId)
    //{
    //    var requests = await _context.DonorDonationRequests
    //        .Where(r => r.DonorId == donorId)
    //        .Include(r => r.DonationRequest)
    //            .ThenInclude(dr => dr.Hospital)
    //                .ThenInclude(h => h.Area)
    //        .ToListAsync();

    //    return _mapper.Map<List<RequestDashboardDto>>(requests);
    //}
}