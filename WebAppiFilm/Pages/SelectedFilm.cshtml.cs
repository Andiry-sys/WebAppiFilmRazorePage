using FilmService.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FilmModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiFilm.Pages
{
    public class SelectedFilmModel : PageModel
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<SelectedFilmModel> _logger;
        private Film _film=new();
        
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public string? Name { get => _film.Name;  }
        public string? Producer { get => _film.Producer;  }
        public string? Style { get => _film.Style;  }
        public string? AboutFilm { get => _film.AboutFilm; }
        public string? Sessions { get => _film.Sessions;  }
        
        public SelectedFilmModel(ILogger<SelectedFilmModel> logger,IFilmService filmService)
        {
            _logger = logger;
            _filmService = filmService;
            
        }
        public void OnGet(int Id)
        {
            id = Id;
            _film = _filmService.GetFilm(id);
        }

        public IActionResult OnPostDelete(int id)
        {
            _filmService.Delete(id);
            return RedirectToPage("/Filmes");
        }

        public void OnPostUpdate(Film film)
        {
            _filmService.Update(film);
        }
        
    }
}
