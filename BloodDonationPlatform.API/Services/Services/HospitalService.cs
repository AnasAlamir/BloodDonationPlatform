using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.Repositories;
using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BloodDonationPlatform.API.Services.Services
{

    public class HospitalService : IHospitalService
    {
        private readonly BloodDonationDbContext _context;
        private readonly IMapper _mapper;

        public HospitalService(BloodDonationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateHospitalDTO> CreateHospitalAsync(CreateHospitalDTO hospitalDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalDto);

            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospitalDto;
        }

        public async Task<bool> DeleteHospitalAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null) throw new HospitalNotFoundExceptions(id);

            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<GetHospitalDTO>> GetAllHospitalsAsync()
        {
            var hospitals = await _context.Hospitals.ToListAsync();
            var Result = _mapper.Map<IEnumerable<GetHospitalDTO>>(hospitals);
            return Result;
        }

        public async Task<GetHospitalDTO> GetHospitalByIdAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            return hospital == null ? null : _mapper.Map<GetHospitalDTO>(hospital);
        }

        public async Task<UpdateHospitalDTO> UpdateHospitalAsync(int id, UpdateHospitalDTO hospitalDto)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null)
                throw new HospitalcreateOrUpdateBadRequestException();

            var updatedHospital = _mapper.Map(hospitalDto, hospital);
            await _context.SaveChangesAsync();
            var reslut = _mapper.Map<UpdateHospitalDTO>(updatedHospital);
            return reslut;

        }

    }
}

    







