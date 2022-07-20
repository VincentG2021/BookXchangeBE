using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ExemplaireApiController : ControllerBase
    {
        IExemplaireService _exemplaireService;

        public ExemplaireApiController(ExemplaireService exemplaireService)
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
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetExemplairebyEdition(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByEdition(id);
            //.OrderBy(e => e.Parution);

            return Ok(exemplaires.ToArray());
        }

    }
}
