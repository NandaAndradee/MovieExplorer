using MovieExplorer.Service.ViewModels;

namespace MovieExplorer.Service.Interfaces
{
    public interface IMovieService 
    {
        Task<IEnumerable<MovieViewModel>> GetAll(CancellationToken cancellationToken);
        Task<IEnumerable<MovieViewModel>> FindByName(string name, CancellationToken cancellationToken, int page = 1);
        Task<MovieViewModel?> GetById(Guid id, CancellationToken cancellationToken);
    }
}
