namespace BloodDonationPlatform.API.Exceptions
{
    public class NotFoundExcptiondonorDonationRequest(int id) : Exception($"Donor Donation Request with ID {id} not found.")
    {
    }
}
