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
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public HospitalService(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<GetHospitalDTO> CreateHospitalAsync(CreateHospitalDTO hospitalDto)
            {
                var hospital = _mapper.Map<Hospital>(hospitalDto);

                var inventory = new Inventory
                {
                    MinimunQuantity = hospitalDto.MinimumBloodQuantityByLiter,
                    CurrentQuantity = hospitalDto.MinimumBloodQuantityByLiter,
                    Hospital = hospital // link via navigation property
                };

                _unitOfWork.HospitalRepository.Insert(hospital);
                _unitOfWork.InventoryRepository.Insert(inventory);
                await _unitOfWork.Save();

                // Reload with Area + Inventory for mapping
                var createdHospital = await _context.Hospitals
                    .Include(h => h.Area)
                    .Include(h => h.Inventory)
                    .FirstAsync(h => h.Id == hospital.Id);

                return _mapper.Map<GetHospitalDTO>(createdHospital);
        }

            public async Task<bool> DeleteHospitalAsync(int id)///already DELETE INVENTORY also
            {
                var hospital = await _context.Hospitals.GetById(id);
                if (hospital == null) throw new HospitalNotFoundExceptions(id);

                _context.Hospitals.Remove(hospital);
                await _context.SaveChangesAsync();
                return true;
            }
            
            public async Task<IEnumerable<GetHospitalDTO>> GetAllHospitalsAsync()
            {
                var hospitals = await _context.Hospitals.ToListAsync();
                return _mapper.Map<IEnumerable<GetHospitalDTO>>(hospitals);
            }

            public async Task<GetHospitalDTO> GetHospitalByIdAsync(int id)
            {
                var hospital = await _context.Hospitals.FindAsync(id);
                return hospital == null ? null : _mapper.Map<GetHospitalDTO>(hospital);
            }

            public async Task<GetHospitalDTO> UpdateHospitalAsync(int id, UpdateHospitalDTO hospitalDto)
            {
                var hospital = await _context.Hospitals.FindAsync(id);
                if (hospital == null) throw new HospitalNotFoundExceptions(id);

                _mapper.Map(hospitalDto, hospital);
                await _context.SaveChangesAsync();

                return _mapper.Map<GetHospitalDTO>(hospital);
            }
        }

    }




