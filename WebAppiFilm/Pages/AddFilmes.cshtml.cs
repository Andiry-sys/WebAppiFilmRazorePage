using FilmModel;
using FilmService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppiFilm.Pages
{
    public class AddFilmesModel : PageModel
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<SelectedFilmModel> _logger;
        private Film _film = new();

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public string? Name { get => _film.Name; }
        public string? Producer { get => _film.Producer; }
        public string? Style { get => _film.Style; }
        public string? AboutFilm { get => _film.AboutFilm; }
        public string? Sessions { get => _film.Sessions; }

        public AddFilmesModel(ILogger<SelectedFilmModel> logger,IFilmService filmService)
        {
            _logger = logger;
            _filmService = filmService;

        }
        public IActionResult OnPostAdd(Film film)
        {
            _filmService.Add(film);
            return RedirectToPage("/Films");
        }
    }
}
