using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IServicesManager 
    {
        IHospitalService HospitalService { get; }
        IInventoryService InventoryService { get; }
        //IDonationRequestService DonationRequestService { get; }
    }
}
