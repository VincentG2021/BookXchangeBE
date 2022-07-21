using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.API.Controllers
{
    [ApiController]
    [Route("BookXchangeAPI/[controller]/[action]")]

    public class EditionController : ControllerBase
    {
        IEditionService _editionService;

        public EditionController(EditionService editionService)
        {
            _editionService = editionService;
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
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetEditionByLivre(int id)
        {
            IEnumerable<EditionDTO> editions = _editionService.GetByLivre(id);
                                        //.OrderBy(e => e.Parution);

            return Ok(editions.ToArray());
        }
    }
}


