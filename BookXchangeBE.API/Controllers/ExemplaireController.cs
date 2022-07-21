using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.API.Controllers
{
    [ApiController]
    [Route("BookXchangeAPI/[controller]/[action]")]

    public class ExemplaireController : ControllerBase
    {
        IExemplaireService _exemplaireService;

        public ExemplaireController(ExemplaireService exemplaireService)
        {
            _exemplaireService = exemplaireService;
        }

        //[Authorize("isConnected")]
        [HttpGet(Name = "GetAllExemplairesList")]
        public IActionResult GetAllExemplairesList()
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetAll()
                                        .OrderBy(b => b.IdMembre);

            return Ok(exemplaires.ToArray());
        }

        //[Authorize("isConnected")]
        [HttpGet(Name = "GetExemplaireList")]
        public IActionResult GetExemplaireList()
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetAll();

            return Ok(exemplaires.ToArray());
        }


        //[Authorize("isConnected")]
        [HttpGet("{id}")]

        public IActionResult GetExemplaireListByMember(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByMembre(id);

            return Ok(exemplaires.ToArray());
        }

        //[Authorize("isConnected")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetExemplairebyEdition(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByEdition(id);
            //.OrderBy(e => e.Parution);

            return Ok(exemplaires.ToArray());
        }

        //[Authorize("isConnected")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetExemplairebyLivre(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByLivre(id);

            return Ok(exemplaires.ToArray());
        }

    }
}
