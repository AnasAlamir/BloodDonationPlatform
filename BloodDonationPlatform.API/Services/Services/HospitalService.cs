using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.Interfaces;
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
        public async Task<bool> DeleteHospitalAsync(int id)///already DELETE INVENTORY as its cascade
        {
            var hospital = await _unitOfWork.HospitalRepository.GetByIdAsync(id);
            if (hospital == null) throw new HospitalNotFoundExceptions(id);

            await _unitOfWork.HospitalRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }
        public async Task<GetHospitalDTO?> GetHospitalByIdAsync(int id)
        {
            var hospital = await _unitOfWork.HospitalRepository.GetByIdWithAreaInventoryIncludedAsync(id);
            if (hospital == null)
                return null;
            return _mapper.Map<GetHospitalDTO>(hospital);
        }
        public async Task<IEnumerable<GetHospitalDTO>> GetAllHospitalsAsync()
        {
            var hospitals = await _unitOfWork.HospitalRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetHospitalDTO>>(hospitals);
        }
        public async Task<GetHospitalDTO> CreateHospitalAsync(CreateHospitalDTO hospitalDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalDto);
            var inventories = Enumerable.Range(1, 8)
                .Select(i => new Inventory
                {
                    BloodTypeId = i,
                    MinimunQuantity = hospitalDto.MinimumBloodQuantityByLiter,
                    CurrentQuantity = hospitalDto.MinimumBloodQuantityByLiter,
                    Hospital = hospital // navigation property
                })
                .ToList();

            await _unitOfWork.HospitalRepository.InsertAsync(hospital);
            await _unitOfWork.InventoryRepository.InsertRangeAsync(inventories);
            await _unitOfWork.SaveAsync();

            // Reload with Area + Inventory for mapping
            var createdHospital = await _unitOfWork.HospitalRepository.GetByIdWithAreaInventoryIncludedAsync(hospital.Id);
            if (createdHospital == null)
                throw new InvalidOperationException();

            return _mapper.Map<GetHospitalDTO>(createdHospital);
        }
        //public async Task<GetHospitalDTO?> UpdateHospitalAsync(int id, UpdateHospitalDTO hospitalDto)
        //{
        //    var hospital = await _unitOfWork.HospitalRepository.GetByIdWithAreaInventoryIncludedAsync(id);
        //    if (hospital == null) throw new HospitalcreateOrUpdateBadRequestException();

        //    // AutoMapper will now also update inventories
        //    _mapper.Map(hospitalDto, hospital);

        //    await _unitOfWork.SaveAsync();

        //    // Reload to ensure Area + Inventory navigation properties are populated
        //    var updated = await _unitOfWork.HospitalRepository.GetByIdWithAreaInventoryIncludedAsync(id);

        //    return _mapper.Map<GetHospitalDTO>(updated);

        //    //var hospital = await _unitOfWork.HospitalRepository.GetByIdWithAreaInventoryIncludedAsync(id);
        //    //if (hospital == null) throw new HospitalcreateOrUpdateBadRequestException();

        //    //var updatedHospital = _mapper.Map(hospitalDto, hospital);
        //    //await _unitOfWork.SaveAsync();

        //    //return _mapper.Map<GetHospitalDTO>(updatedHospital);
        //}
        public async Task<GetHospitalDTO?> UpdateHospitalAsync(int id, UpdateHospitalDTO dto)
        {
            var hospital = await _unitOfWork.HospitalRepository
                .GetByIdWithAreaInventoryIncludedAsync(id);
            if (hospital == null) throw new HospitalcreateOrUpdateBadRequestException();

            _mapper.Map(dto, hospital);         // mutates scalars + child items (AfterMap)
            await _unitOfWork.SaveAsync();      // single save

            // Reload so Area/Inventory navigations are populated for mapping
            var updated = await _unitOfWork.HospitalRepository
                .GetByIdWithAreaInventoryIncludedAsync(id);

            return _mapper.Map<GetHospitalDTO>(updated);
        }
    }
}