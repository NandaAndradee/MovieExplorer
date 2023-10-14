using Microsoft.EntityFrameworkCore;
using MovieExplorer.Data.Context;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Data.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Movie>> GetByName(string name, CancellationToken cancellationToken)
        {
            return await DbSet.Where(x => x.Title.ToLower().Contains(name.ToLower()) ||
            x.Description.ToLower().Contains(name.ToLower()) ||
            x.OriginalTitle.ToLower().Contains(name.ToLower()))
                .ToListAsync(cancellationToken);
        }
    }
}
