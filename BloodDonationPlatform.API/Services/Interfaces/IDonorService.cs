using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonorService
    {
        IEnumerable<Donor> GetAll();
    }
}
