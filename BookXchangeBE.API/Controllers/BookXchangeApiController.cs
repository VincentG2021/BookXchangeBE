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
    [Route("[controller]/[action]")]

    public class BookXchangeAPIController : ControllerBase
    {
        IMembreService _membreService;
        ILivreService _livreService;
        IEditionService _editionService;
        IExemplaireService _exemplaireService;

        public BookXchangeAPIController(LivreService livreService, MembreService memberService, EditionService editionService, ExemplaireService exemplaireService)
        {

            _livreService = livreService;
            _membreService = memberService;
            _editionService = editionService;
            _exemplaireService = exemplaireService;
        }

        [Authorize("isConnected")]
        [HttpGet(Name = "GetBookList")]
        public IActionResult GetBookList()
        {
            IEnumerable<LivreDTO> livres = _livreService.GetAll()
                                        .OrderBy(b => b.Titre);

            return Ok(livres.ToArray());
        }

        [Authorize("isConnected")]
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
        public IActionResult Login(ApiMembreLogin form)
        {
            //if (!ModelState.IsValid) return BadRequest();

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
        [HttpGet("{pseudo}")]
        //[HttpGet("{id}", Name = "GetMemberProfile")]

        public IActionResult GetMemberProfile(string pseudo)
        {
            try
            {
                ApiConnectedMemberModel connectedMember = _membreService.GetMemberProfile(pseudo).ToApiConnected();

                if(connectedMember == null)
                {
                    return NotFound();
                }
                return Ok(connectedMember);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }                           
        }

        //[Authorize("isConnected")]
        [HttpGet(Name = "GetEditionList")]
        public IActionResult GetEditionList()
        {
            IEnumerable<EditionDTO> editions = _editionService.GetAll()
                                        .OrderBy(b => b.Format);

            return Ok(editions.ToArray());
        }

        //[Authorize("isConnected")]
        [HttpGet(Name = "GetExemplaireList")]
        public IActionResult GetExemplaireList()
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetAll();

            return Ok(exemplaires.ToArray());
        }

        //[Authorize("isConnected")]
        [HttpGet(Name = "GetMemberExemplaireList")]
        public IActionResult GetMemberExemplaireList(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByMembre(id);

            return Ok(exemplaires.ToArray());
        }

    }
}
