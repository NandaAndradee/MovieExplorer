using MovieExplorer.Domain.Models;

namespace MovieExplorer.Domain.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public Task<IEnumerable<Movie>> GetByName(string name, CancellationToken cancellationToken);
    }
}
