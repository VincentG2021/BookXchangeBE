using BookXchangeBE.BLL.DTO;
using BookXchangeBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Mappers
{
    public static class LivreMapper
    {
        public static LivreDTO ToDTO(this LivreEntity entity)
        {
            return new LivreDTO()
            {
                IdLivre = entity.IdLivre,
                Titre = entity.Titre,
                Auteur = entity.Auteur,
                Synopsis = entity.Synopsis,
            };
        }

        public static LivreEntity ToEntity(this LivreDTO dto)
        {
            return new LivreEntity()
            {
                IdLivre = dto.IdLivre,
                Titre = dto.Titre,
                Auteur = dto.Auteur,
                Synopsis = dto.Synopsis,
            };
        }

    }
}
