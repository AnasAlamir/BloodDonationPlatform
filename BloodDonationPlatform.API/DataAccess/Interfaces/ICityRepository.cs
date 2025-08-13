using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City? GetById(int id);
    }
}
