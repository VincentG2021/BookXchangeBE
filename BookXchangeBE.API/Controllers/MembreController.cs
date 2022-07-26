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
    [Route("BookXchangeAPI/[controller]/[action]")]

    public class MembreController : ControllerBase
    {
        IMembreService _membreService;
        ILivreService _livreService;
        IEditionService _editionService;
        IExemplaireService _exemplaireService;

        public MembreController(LivreService livreService, MembreService memberService, EditionService editionService, ExemplaireService exemplaireService)
        {

            _livreService = livreService;
            _membreService = memberService;
            _editionService = editionService;
            _exemplaireService = exemplaireService;
        }

        //[Authorize("isConnected")]
        [AllowAnonymous]
        [HttpGet(Name = "GetBookList")]
        public IActionResult GetBookList()
        {
            IEnumerable<LivreDTO> livres = _livreService.GetAll()
                                        .OrderBy(b => b.Titre);

            return Ok(livres.ToArray());
        }

        [Authorize("isConnected")]
        [HttpGet(Name = "GetMembreList")]
        public IActionResult GetMembreList()
        {
            IEnumerable<MembreDTO> membres = _membreService.GetAll()
                                        .OrderBy(b => b.Pseudo);

            return Ok(membres.ToArray());
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(ApiMembreModel membre)
        {
            MembreDTO dto = _membreService.Insert(membre.Pseudo, membre.Email, membre.Pwd, membre.Role);
            if (dto != null)
            {
                //return new CreatedResult("/BookXchangeAPI/Membre", dto);
                ApiConnectedMemberModel connectedMember = _membreService.ConnectMember(membre.Pseudo, membre.Pwd).ToApiConnected();

                return Ok(connectedMember);
            }
            else
            {
                return new BadRequestObjectResult(membre);
            }
        }


        [AllowAnonymous]
        [HttpPost]
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
        [HttpGet("{id}")]
        //[HttpGet("{id}", Name = "GetMemberProfile")]

        public IActionResult GetMembreById(int id)
        {
            try
            {
                ApiMembreModel membre = _membreService.GetById(id).ToAPI();

                if (membre == null)
                {
                    return NotFound();
                }
                return Ok(membre);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex}");
            }
        }

        //[Authorize("isConnected")]
        [HttpGet("{pseudo}")]
        //[HttpGet("{id}", Name = "GetMemberProfile")]

        public IActionResult GetMemberProfile(string pseudo)
        {
            try
            {
                ApiConnectedMemberModel connectedMember = _membreService.GetMemberProfile(pseudo).ToApiConnected();

                if (connectedMember == null)
                {
                    return NotFound();
                }
                return Ok(connectedMember);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
