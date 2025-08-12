using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly BloodDonationDbContext _dbContext;
        private readonly DbSet<TEntity> _entitiy;
        public BaseRepository(BloodDonationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _entitiy = _dbContext.Set<TEntity>();
        }
        public void Delete(int id)
        {
            var entity = _entitiy.Find(id);
            if (entity != null)
            {
                _entitiy.Remove(entity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entitiy.AsEnumerable();
        }

        public TEntity? GetById(int id)
        {
            return _entitiy.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _entitiy.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entitiy.Update(entity);
        }
    }
}
