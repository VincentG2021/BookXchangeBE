﻿using BookXchangeBE.API.Mappers;
using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.API.Controllers
{
    [ApiController]
    [Route("BookXchangeAPI/[controller]/[action]")]

    public class LivreController : ControllerBase
    {
        ILivreService _livreService;
        public LivreController(LivreService livreService)
        {
            _livreService = livreService;
        }

        [AllowAnonymous]
        //[Authorize("isConnected")]
        [HttpPost]
        public IActionResult CreateLivre(ApiLivreModel livre)
        {
            LivreDTO created = _livreService.Insert(livre.Titre, livre.Auteur, livre.Synopsis);
            if (created != null)
            {
                return Ok(created);
                //return new CreatedResult("/api/bookList", created);

            }
            else
            {
                return new BadRequestObjectResult(livre);
            }
        }

        //[Authorize("isConnected")]
        [AllowAnonymous]
        [HttpGet(Name = "ReadLivreList")]
        public IActionResult ReadLivreList()
        {
            IEnumerable<LivreDTO> livres = _livreService.GetAll()
                                        .OrderBy(b => b.Titre);

            return Ok(livres.ToArray());
        }


        //[AllowAnonymous]
        [HttpPut]
        public IActionResult UpdateLivre(ApiLivreModel livre)
        {
            bool updated = _livreService.Update(livre.IdLivre, livre.ToDTO());
            if (updated)
            {
                return Ok(updated);
                //return new CreatedResult("/api/bookList", updated);
            }
            else
            {
                return new BadRequestObjectResult(livre);
            }
        }

        //[AllowAnonymous]
        [Authorize("isConnected")]
        [HttpDelete("{id}")]
        public IActionResult DeleteLivre(int id)
        {
            bool deleted = _livreService.Delete(id);
            if (deleted)
            {
                return Ok(deleted);
            }
            else
            {
                return new BadRequestObjectResult(id);
            }
        }
    }
}
