using MovieExplorer.Domain.Models;

namespace MovieExplorer.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        public Task<T?> GetById(Guid id, CancellationToken cancellationToken);
        public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        public Task Save(T entity, CancellationToken cancellationToken);
    }
}
