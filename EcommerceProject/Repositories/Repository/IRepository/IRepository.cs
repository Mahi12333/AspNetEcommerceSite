using System.Linq.Expressions;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        // Add other common methods here
    }
}
