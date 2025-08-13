using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BloodDonationDbContext _dbContext;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodTypeRepository _bloodTypeRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IDonationRequestRepository _donationRequestRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IDonorDonationRequestRepository _donorDonationRequestRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly ICityRepository _cityRepository;

        public UnitOfWork(BloodDonationDbContext dbContext,
                            IDonorRepository donorRepository,
                            IBloodTypeRepository bloodTypeRepository,
                            IAdminRepository adminRepository,
                            IDonationRequestRepository donationRequestRepository,
                            IHospitalRepository hospitalRepository,
                            IInventoryRepository inventoryRepository,
                            IDonorDonationRequestRepository donorDonationRequestRepository,
                            IAreaRepository areaRepository,
                            ICityRepository cityRepository)
        {
            _dbContext = dbContext;
            _donorRepository = donorRepository;
            _bloodTypeRepository = bloodTypeRepository;
            _adminRepository = adminRepository;
            _donationRequestRepository = donationRequestRepository;
            _hospitalRepository = hospitalRepository;
            _inventoryRepository = inventoryRepository;
            _donorDonationRequestRepository = donorDonationRequestRepository;
            _areaRepository = areaRepository;
            _cityRepository = cityRepository;
        }

        public IDonorRepository DonorRepository => _donorRepository;
        public IBloodTypeRepository BloodTypeRepository => _bloodTypeRepository;
        public IAdminRepository AdminRepository => _adminRepository;
        public IDonationRequestRepository DonationRequestRepository => _donationRequestRepository;
        public IHospitalRepository HospitalRepository => _hospitalRepository;
        public IInventoryRepository InventoryRepository => _inventoryRepository;
        public IDonorDonationRequestRepository DonorDonationRequestRepository => _donorDonationRequestRepository;
        public IAreaRepository AreaRepository => _areaRepository;
        public ICityRepository CityRepository => _cityRepository;

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
