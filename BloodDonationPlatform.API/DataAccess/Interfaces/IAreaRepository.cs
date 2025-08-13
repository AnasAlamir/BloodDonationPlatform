using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAll();
        Area? GetById(int id);
    }
}
