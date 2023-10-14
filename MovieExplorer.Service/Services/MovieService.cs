using Microsoft.Extensions.Configuration;
using MovieExplorer.Domain.ApiModels;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Domain.Models;
using MovieExplorer.Service.Interfaces;
using MovieExplorer.Service.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MovieExplorer.Service.Services
{
    public class MovieService : IMovieService
    {
        private const string SEARCH_PATH = "/3/search/movie";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IMovieRepository _movieRepository;

        public MovieService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMovieRepository movieRepository)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieViewModel>> FindByName(string name, CancellationToken cancellationToken, int page = 1)
        {
            var moviesDb = await _movieRepository.GetByName(name, cancellationToken);

            if (moviesDb == null || !moviesDb.Any())
            {
                await GetFromApiAndSave(name, page, cancellationToken);
                moviesDb = await _movieRepository.GetByName(name, cancellationToken);
            }

            return moviesDb.Select(x => new MovieViewModel
            {
                Id = x.Id,
                Title = x.Title,
                OriginalTitle = x.OriginalTitle,
                Description = x.Description,
            });

        }

        private async Task GetFromApiAndSave(string name, int page, CancellationToken cancellationToken)
        {
            var moviesApi = await FindByNameRemote(name, page, cancellationToken);

            if (moviesApi != null)
            {
                await ProccessResponseAsync(moviesApi, cancellationToken);

                for (int currentPage = 2; currentPage <= moviesApi.TotalPages; currentPage++)
                {
                    moviesApi = await FindByNameRemote(name, currentPage, cancellationToken);

                    await ProccessResponseAsync(moviesApi, cancellationToken);
                }
            }
        }

        private async Task<MovieResponse> FindByNameRemote(string name, int page, CancellationToken cancellationToken)
        {
            var queryParams = new Dictionary<string, string> {
                { "include_adult", "false" },
                { "language",  "pt-BR" },
                { "page", page.ToString() },
                { "query", name }
            };

            var queryString = string.Join("&", queryParams.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            var fullUrl = $"{SEARCH_PATH}?{queryString}";

            var httpClient = _httpClientFactory.CreateClient("MOVIE");
            var token = _configuration.GetSection("API").GetValue<string>("Token");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var movieResponse = await httpClient.GetAsync(fullUrl, cancellationToken);

            movieResponse.EnsureSuccessStatusCode();

            var responseContent = await movieResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieResponse>(responseContent)!;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll(cancellationToken);
            return movies.Select(x => new MovieViewModel
            {
                Id = x.Id,
                Title = x.Title,
                OriginalTitle = x.OriginalTitle,
                Description = x.Description
            });
        }

        private async Task ProccessResponseAsync(MovieResponse movies, CancellationToken cancellationToken)
        {
            if (movies == null || !movies.Movies.Any()) return;

            foreach (var item in movies.Movies)
            {
                await _movieRepository.Save(new Movie(Guid.NewGuid(), item.Title, item.OriginalTitle, item.Overview), cancellationToken);
            }
        }

        public async Task<MovieViewModel?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetById(id, cancellationToken);
            if (movie == null) return null;

            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                Description = movie.Description
            };
        }
    }
}
