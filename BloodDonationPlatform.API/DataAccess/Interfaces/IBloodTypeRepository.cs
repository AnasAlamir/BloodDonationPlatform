using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IBloodTypeRepository
    {
        IEnumerable<BloodType> GetAll();
        BloodType? GetById(int id);
    }
}
