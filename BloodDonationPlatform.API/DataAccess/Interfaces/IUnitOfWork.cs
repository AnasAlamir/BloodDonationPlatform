namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IDonorRepository DonorRepository { get; }
        IBloodTypeRepository BloodTypes { get; }
        void Save();
    }
}
