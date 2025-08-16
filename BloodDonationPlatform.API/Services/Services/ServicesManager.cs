using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.Services.Interfaces;

namespace BloodDonationPlatform.API.Services.Services
{
    public class ServicesManager(IMapper mapper, IUnitOfWork unitOfWork, BloodDonationDbContext context) : IServicesManager
    {
        public IInventoryService InventoryService { get; } = new InventoryService(context,mapper);

        IHospitalService IServicesManager.HospitalService { get; } = new HospitalService(context,mapper);

        //IDonationRequestService IServicesManager.DonationRequestService { get; } = new DonationRequestService();
    }
}
