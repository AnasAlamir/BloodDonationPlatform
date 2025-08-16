using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.UnitOfWork;
using BloodDonationPlatform.API.Services.DTOs.BloodType;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.Interfaces;

namespace BloodDonationPlatform.API.Services.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BloodTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BloodTypeDto>> GetAllAsync()
        {
            var bloodTypes = await _unitOfWork.BloodTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BloodTypeDto>>(bloodTypes);
        }

        public async Task<BloodTypeDto?> GetByIdAsync(int id)
        {
            var bloodType = await _unitOfWork.BloodTypeRepository.GetByIdAsync(id);
            return _mapper.Map<BloodTypeDto>(bloodType);
        }
    }
}