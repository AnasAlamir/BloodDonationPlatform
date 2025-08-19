using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly BloodDonationDbContext _dbContext;
        protected readonly DbSet<TEntity> _entity;
        public BaseRepository(BloodDonationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<TEntity>();
        }
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity != null)
            {
                _entity.Remove(entity);
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }
        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _entity.Update(entity);        
        }

    }
}
