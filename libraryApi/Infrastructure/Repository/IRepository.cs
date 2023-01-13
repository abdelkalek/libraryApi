namespace libraryApi.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }

}
