using BloodDonationPlatform.API.Services.DTOs;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IHospitalService 
    {
        Task<IEnumerable<GetHospitalDTO>> GetAllHospitalsAsync();
        Task<GetHospitalDTO> GetHospitalByIdAsync(int id);
        Task<CreateHospitalDTO> CreateHospitalAsync(CreateHospitalDTO hospitalDto);
        Task<UpdateHospitalDTO> UpdateHospitalAsync(int id, UpdateHospitalDTO hospitalDto);
        Task<bool> DeleteHospitalAsync(int id);
    }
}
