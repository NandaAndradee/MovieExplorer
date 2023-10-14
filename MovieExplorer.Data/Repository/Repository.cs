using Microsoft.EntityFrameworkCore;
using MovieExplorer.Data.Context;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly MovieContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(MovieContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Save(T entity, CancellationToken cancellationToken)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            _ = Db.SaveChangesAsync(cancellationToken);
        }
    }
}
