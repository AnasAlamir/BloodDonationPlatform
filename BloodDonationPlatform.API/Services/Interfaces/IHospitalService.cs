using BloodDonationPlatform.API.Services.DTOs;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IHospitalService 
    {
        Task<IEnumerable<GetHospitalDTO>> GetAllHospitalsAsync();
        Task<GetHospitalDTO?> GetHospitalByIdAsync(int id);
        Task<GetHospitalDTO> CreateHospitalAsync(CreateHospitalDTO hospitalDto);
        Task<GetHospitalDTO?> UpdateHospitalAsync(int id, UpdateHospitalDTO hospitalDto);
        Task<bool> DeleteHospitalAsync(int id);
        Task<IEnumerable<GetNameHospitalDTO>> GetAllNameHospitalsAsync();
    }
}
