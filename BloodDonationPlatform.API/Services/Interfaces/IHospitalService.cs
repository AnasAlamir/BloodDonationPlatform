using BloodDonationPlatform.API.Services.DTOs;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IHospitalService 
    {
        Task<IEnumerable<HospitalDTO>> GetAllHospitalsAsync();
        Task<HospitalDTO> GetHospitalByIdAsync(int id);
        Task<HospitalDTO> CreateHospitalAsync(HospitalDTO hospitalDto);
        Task<HospitalDTO> UpdateHospitalAsync(int id, HospitalDTO hospitalDto);
        Task<bool> DeleteHospitalAsync(int id);
    }
}
