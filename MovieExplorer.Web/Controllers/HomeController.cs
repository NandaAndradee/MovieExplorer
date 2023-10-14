using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Service.Interfaces;
using MovieExplorer.Service.ViewModels;

namespace MovieExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _movieService.GetAll(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string movieName, CancellationToken cancellationToken)
        {
            return View(await _movieService.FindByName(movieName, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]Guid id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetById(id, cancellationToken);
            return View(movie);
        }
    }
}