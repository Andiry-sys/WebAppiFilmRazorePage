using FilmService.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FilmModel;

namespace WebAppiFilm.Pages
{
    public class SelectedFilmModel : PageModel
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<SelectedFilmModel> _logger;
        private Film _film=new();
        public int Id { get => _film.Id; }
        public string? Name { get => _film.Name;  }
        public string? Producer { get => _film.Producer;  }
        public string? Style { get => _film.Style;  }
        public string? AboutFilm { get => _film.AboutFilm; }
        public string? Sessions { get => _film.Sessions;  }
        public SelectedFilmModel(ILogger<SelectedFilmModel> logger,IFilmService filmService)
        {
            _logger = logger;
            _filmService = filmService;
            _film = _filmService.GetFilm(Id);
        }
        public void OnGet(int Id)
        {
        }
    }
}
