using BookXchangeBE.API.Mappers;
using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using BookXchangeBE.BLL.Tools;
using BookXchangeBE.Models;
using Microsoft.AspNetCore.Authorization;
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


        [AllowAnonymous]
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


        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Login([FromForm] ApiMembreLogin form)
        {
            if (!ModelState.IsValid) return BadRequest();

            // Validation du hashage du mot de passe
            if (!_membreService.CheckCredentials(form.Pseudo, form.Password))
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return BadRequest();
            }


            ApiConnectedMemberModel connectedMember = _membreService.ConnectMember(form.Pseudo, form.Password).ToApiConnected();

            
            return Ok(connectedMember);
        }
        //[Authorize("isConnected")]
    }
}
