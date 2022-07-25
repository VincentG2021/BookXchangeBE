using BookXchangeBE.API.Mappers;
using BookXchangeBE.API.Models;
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

        // CREATE
        //[Authorize("isConnected")]
        [HttpPost]
        public IActionResult CreateExemplaire(ApiExemplaireModel exemplaire)
        {
            int created = _exemplaireService.CreateExemplaire(exemplaire.ToDTO());
            if (created >0)
            {
                return Ok(created);
                //return new CreatedResult("/api/exemplaireList", created);
            }
            else
            {
                return new BadRequestObjectResult(exemplaire);
            }
        }

        // READ
        //[Authorize("isConnected")]
        [HttpGet("{id}")]
        public IActionResult GetExemplaireById(int id)
        {
            ExemplaireDTO exemplaire = _exemplaireService.GetById(id);
            return Ok(exemplaire);
        }

        //[Authorize("isConnected")]
        [AllowAnonymous]
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
        [HttpGet("{id}")]
        public IActionResult GetExemplaireListbyLivre(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByLivre(id);
            return Ok(exemplaires.ToArray());
        }

        //[Authorize("isConnected")]
        [HttpGet("{id}")]
        public IActionResult GetExemplaireListbyEdition(int id)
        {
            IEnumerable<ExemplaireDTO> exemplaires = _exemplaireService.GetByEdition(id);
            //.OrderBy(e => e.Parution);
            return Ok(exemplaires.ToArray());
        }

        // UPDATE
        //[Authorize("isConnected")]
        [HttpPut]
        public IActionResult UpdateExemplaire(ApiExemplaireModel exemplaire)
        {
            bool updated = _exemplaireService.UpdateExemplaire(exemplaire.ToDTO());
            if (updated)
            {
                return Ok(updated);
                //return new CreatedResult("/api/exemplaireList", created);
            }
            else
            {
                return new BadRequestObjectResult(exemplaire);
            }
        }

        // DELETE
        //[Authorize("isConnected")]
        [HttpDelete("{id}")]
        public IActionResult DeleteExemplaire(int id)
        {
            bool deleted = _exemplaireService.Delete(id);
            if (deleted)
            {
                return Ok(deleted);
                //return new CreatedResult("/api/bookList", created);
            }
            else
            {
                return new BadRequestObjectResult(id);
            }
        }
    }
}
