using FilmModel;
using FilmService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppiFilm.Pages
{
    public class FilmesModel : PageModel
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<Film> _logger;
        public List<Film> Films { get; set; }
        public FilmesModel (ILogger<Film> logger, IFilmService filmService)
        {
            _filmService = filmService;
            _logger = logger;
            Films  = _filmService.GetFilms();

        }
        
        public void OnPost(string text)
        {
            Films = _filmService.FilterFilms(text);
        }
        
        public IActionResult OnGetAdd()
        {
            return RedirectToPage("/FilmesAdd");
        }
    }
}
