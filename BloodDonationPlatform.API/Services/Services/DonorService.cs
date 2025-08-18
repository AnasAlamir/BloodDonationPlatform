using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Doner;
using Microsoft.EntityFrameworkCore;
using BloodDonationPlatform.API.Services.Interfaces;
using System;

public class DonorService : IDonorService
{
    private readonly BloodDonationDbContext _context;
    private readonly IMapper _mapper;

    public DonorService(BloodDonationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DonorDto?> GetDonorByIdAsync(int donorId)
    {
        var donor = await _context.Donors
            .Include(d => d.BloodType)
            .Include(d => d.Area)
            .FirstOrDefaultAsync(d => d.Id == donorId);

        return donor == null ? null : _mapper.Map<DonorDto>(donor);
    }

    public async Task<List<RequestDashboardDto>> GetRequestsForDonorAsync(int donorId)
    {
        var requests = await _context.DonorDonationRequests
            .Where(r => r.DonorId == donorId)
            .Include(r => r.DonationRequest)
                .ThenInclude(dr => dr.Hospital)
                    .ThenInclude(h => h.Area)
            .ToListAsync();

        return _mapper.Map<List<RequestDashboardDto>>(requests);
    }
}
