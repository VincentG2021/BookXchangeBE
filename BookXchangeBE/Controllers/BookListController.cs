using BookXchangeBE.BLL.Services;
using BookXchangeBE.Models;
using BookXchangeBE.Models.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.Controllers
{
    public class BookListController : Controller
    {
        private LivreService livreService;

        public BookListController(LivreService livreService)
        {
            this.livreService = livreService;
        }

        public IActionResult Index()
        {
            IEnumerable<Livre> livres = livreService.GetAll()
                .Select(b => b.ToModel())
                .OrderBy(b => b.Titre);

            return View(livres);
        }
    }
}
