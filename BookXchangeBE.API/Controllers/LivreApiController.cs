﻿using BookXchangeBE.API.Mappers;
using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class LivreApiController : ControllerBase
    {
        ILivreService _livreService;
        public LivreApiController(LivreService livreService)
        {
            _livreService = livreService;
        }

        [AllowAnonymous]
        //[Authorize("isConnected")]
        [HttpPost]
        public IActionResult AddLivre(ApiLivreModel livre)
        {
            LivreDTO dto = _livreService.Insert(livre.Titre, livre.Auteur, livre.Synopsis);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return new BadRequestObjectResult(livre);
            }
        }

        //[AllowAnonymous]
        [HttpPut]
        public IActionResult UpdateLivre(ApiLivreModel livre)
        {
            bool updated = _livreService.Update(livre.IdLivre, livre.ToDTO());
            if (updated != false)
            {
                return new CreatedResult("/api/bookList", updated);
            }
            else
            {
                return new BadRequestObjectResult(livre);
            }
        }

        //[AllowAnonymous]
        [HttpDelete]
        public IActionResult DeleteLivre(int id)
        {
            bool deleted = _livreService.Delete(id);
            if (deleted != false)
            {
                return new CreatedResult("/api/bookList", deleted);
            }
            else
            {
                return new BadRequestObjectResult(id);
            }
        }
    }
}
