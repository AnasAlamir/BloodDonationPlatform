using Azure.Core;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonationRequestService
    {
        int GetOpendDonationRequestsNumber();
        int GetPendingDonationRequestsNumber();
    }
}
