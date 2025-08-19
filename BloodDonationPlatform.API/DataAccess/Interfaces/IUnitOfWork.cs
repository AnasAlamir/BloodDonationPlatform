namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IDonorRepository DonorRepository { get; }
        IAdminRepository AdminRepository { get; }
        IBloodTypeRepository BloodTypeRepository { get; }
        IDonationRequestRepository DonationRequestRepository { get; }
        IHospitalRepository HospitalRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IDonorDonationRequestRepository DonorDonationRequestRepository { get; }
        IAreaRepository AreaRepository { get; }
        ICityRepository CityRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
