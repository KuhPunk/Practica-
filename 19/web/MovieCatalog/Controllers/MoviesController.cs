using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Models;
using MovieCatalog.Models.ViewModels;
using MovieCatalog.Services;

namespace MovieCatalog.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: /Movies/Index
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        // GET: /Movies/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _movieService.GetMovieByIdAsync(id.Value);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // GET: /Movies/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Movies/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(MovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Title = viewModel.Title,
                    Genre = viewModel.Genre,
                    Year = viewModel.Year,
                    Rating = viewModel.Rating
                };

                await _movieService.AddMovieAsync(movie);
                TempData["SuccessMessage"] = "Фильм успешно добавлен!";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Movies/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _movieService.GetMovieByIdAsync(id.Value);
            if (movie == null) return NotFound();

            var viewModel = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Year = movie.Year,
                Rating = movie.Rating
            };

            return View(viewModel);
        }

        // POST: /Movies/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    Genre = viewModel.Genre,
                    Year = viewModel.Year,
                    Rating = viewModel.Rating
                };

                await _movieService.UpdateMovieAsync(movie);
                TempData["SuccessMessage"] = "Фильм успешно обновлен!";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Movies/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _movieService.GetMovieByIdAsync(id.Value);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // POST: /Movies/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            TempData["SuccessMessage"] = "Фильм успешно удален!";
            return RedirectToAction(nameof(Index));
        }
    }
}
