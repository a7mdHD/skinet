using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();
         Task<T> GetEntityWithSpec(ISpecification<T> spec);
         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        //this method count the no. of itmes after the filter has been applied.
        Task<int> CountAsync(ISpecification<T> spec); 

    }
}