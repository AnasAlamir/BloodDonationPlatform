using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly BloodDonationDbContext _dbContext;
        private readonly DbSet<TEntity> _entity;
        public BaseRepository(BloodDonationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<TEntity>();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity != null)
            {
                _entity.Remove(entity);
            }
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }
        public async Task InsertAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            _entity.Update(entity);        
        }

    }
}
