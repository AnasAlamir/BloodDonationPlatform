using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.Repositories;
using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs;
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

            public async Task<HospitalDTO> CreateHospitalAsync(HospitalDTO hospitalDto)
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

            public async Task<IEnumerable<HospitalDTO>> GetAllHospitalsAsync()
            {
                var hospitals = await _context.Hospitals.ToListAsync();
                return _mapper.Map<IEnumerable<HospitalDTO>>(hospitals);
            }

            public async Task<HospitalDTO> GetHospitalByIdAsync(int id)
            {
                var hospital = await _context.Hospitals.FindAsync(id);
                return hospital == null ? null : _mapper.Map<HospitalDTO>(hospital);
            }

            public async Task<HospitalDTO> UpdateHospitalAsync(int id, HospitalDTO hospitalDto)
            {
                var hospital = await _context.Hospitals.FindAsync(id);
                if (hospital == null) throw new HospitalNotFoundExceptions(id);

                _mapper.Map(hospitalDto, hospital);
                await _context.SaveChangesAsync();

                return _mapper.Map<HospitalDTO>(hospital);
            }
        }

    }




