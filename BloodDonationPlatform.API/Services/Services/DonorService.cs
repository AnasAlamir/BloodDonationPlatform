//using BloodDonationPlatform.API.DataAccess.Interfaces;
//using BloodDonationPlatform.API.DataAccess.Models;
//using BloodDonationPlatform.API.Services.Interfaces;

//namespace BloodDonationPlatform.API.Services.Services
//{
//    internal class DonorService : IDonorService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public DonorService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public IEnumerable<Donor> GetAll()
//        {
//            return _unitOfWork.DonorRepository.GetAllAreasAsync();
//        }
//    }
//}
