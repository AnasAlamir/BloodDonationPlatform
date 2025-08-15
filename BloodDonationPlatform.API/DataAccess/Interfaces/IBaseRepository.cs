namespace BloodDonationPlatform.API.DataAccess.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
    }
}
