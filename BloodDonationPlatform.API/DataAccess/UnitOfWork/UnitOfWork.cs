using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BloodDonationDbContext _dbContext;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodTypeRepository _bloodTypeRepository;

        public UnitOfWork(BloodDonationDbContext dbContext,
                            IDonorRepository donorRepository,
                            IBloodTypeRepository bloodTypeRepository)
        {
            _dbContext = dbContext;
            _donorRepository = donorRepository;
            _bloodTypeRepository = bloodTypeRepository;
        }

        public IDonorRepository DonorRepository => _donorRepository;
        public IBloodTypeRepository BloodTypes => _bloodTypeRepository;

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
