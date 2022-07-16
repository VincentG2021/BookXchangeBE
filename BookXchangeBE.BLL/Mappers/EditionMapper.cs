using BookXchangeBE.BLL.DTO;
using BookXchangeBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Mappers
{
    public static class EditionMapper
    {
        public static EditionDTO ToDTO(this EditionEntity entity)
        {
            return new EditionDTO()
            {
                IdEdition = entity.IdEdition,
                Isbn = entity.Isbn,
                Parution = entity.Parution,
                Format = entity.Format,
                IdLivre = entity.IdLivre,

                //Titre = entity.Titre,
                //Auteur = entity.Auteur,
                //Synopsis = entity.Synopsis

            };
        }

        public static EditionEntity ToEntity(this EditionDTO dto)
        {
            return new EditionEntity()
            {
                IdEdition = dto.IdEdition,
                Isbn = dto.Isbn,
                Parution = dto.Parution,
                Format = dto.Format,
                IdLivre = dto.IdLivre,

                //Titre = dto.Titre,
                //Auteur = dto.Auteur,
                //Synopsis = dto.Synopsis

            };
        }

    }
}
