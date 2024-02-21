namespace WebApiMeteo.Repository.Interfaces
{
    public interface ICRUDRepository<T>
    {
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
