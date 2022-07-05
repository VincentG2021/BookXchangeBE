using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class BookXchangeAPIController : ControllerBase
    {
        ILivreService _livreService;
        IMembreService _membreService;
        public BookXchangeAPIController(LivreService livreService, MembreService memberService)
        {
            this._livreService = livreService;
            this._membreService = memberService;
        }

        [HttpGet(Name = "GetBookList")]

        public IActionResult GetBookList()
        {
            IEnumerable<LivreDTO> livres = _livreService.GetAll()
                                        .OrderBy(b => b.Titre);

            return Ok(livres.ToArray());
        }

        [HttpGet(Name = "GetMemberList")]

        public IActionResult GetMemberList()
        {
            IEnumerable<MembreDTO> membres = _membreService.GetAll()
                                        .OrderBy(b => b.Pseudo);

            return Ok(membres.ToArray());
        }



        [HttpPost]
        public IActionResult RegisterMembre(ApiMembreModel membre)
        {
            MembreDTO dto = _membreService.Insert(membre.Pseudo, membre.Email, membre.Pwd, membre.Role);
            if (dto != null)
            {
                return new CreatedResult("/api/Membres", dto);
            }
            else
            {
                return new BadRequestObjectResult(membre);
            }
        }
    }
}
