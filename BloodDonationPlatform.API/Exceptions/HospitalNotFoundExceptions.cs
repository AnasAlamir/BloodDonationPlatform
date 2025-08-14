namespace BloodDonationPlatform.API.Exceptions
{
    public class HospitalNotFoundExceptions(int id) : NotfoundExceptions($"Hospital with id {id} not found")
    {
    }
}
