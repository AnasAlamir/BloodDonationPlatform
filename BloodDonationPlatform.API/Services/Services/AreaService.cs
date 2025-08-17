using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.UnitOfWork;
using BloodDonationPlatform.API.Services.DTOs.Area;
using BloodDonationPlatform.API.Services.DTOs.BloodType;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.Interfaces;

namespace BloodDonationPlatform.API.Services.Services
{
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AreaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AreaDto>> GetAllAsync()
        {
            var areas = await _unitOfWork.AreaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AreaDto>>(areas);
        }

        public async Task<AreaDto?> GetByIdAsync(int id)
        {
            var area = await _unitOfWork.AreaRepository.GetByIdAsync(id);
            return _mapper.Map<AreaDto>(area);
        }
    }
}