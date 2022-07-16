using BookXchangeBE.BLL.DTO;
using BookXchangeBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Mappers
{
    public static class ExemplaireMapper
    {
        public static ExemplaireDTO ToDTO(this ExemplaireEntity entity)
        {
            return new ExemplaireDTO()
            {
                IdExemplaire = entity.IdExemplaire,
                IdEdition = entity.IdEdition,
                IdMembre = entity.IdMembre,

                IdLivre = entity.IdLivre,
                Titre = entity.Titre,
                Auteur = entity.Auteur,
                Synopsis = entity.Synopsis,

                Isbn = entity.Isbn,
                Parution = entity.Parution,
                Format = entity.Format
            };
        }

        public static ExemplaireEntity ToEntity(this ExemplaireDTO dto)
        {
            return new ExemplaireEntity()
            {
                IdEdition = dto.IdEdition,
                IdExemplaire = dto.IdExemplaire,
                IdMembre = dto.IdMembre,

                IdLivre = dto.IdLivre,
                Titre = dto.Titre,
                Auteur = dto.Auteur,
                Synopsis = dto.Synopsis,

                Isbn = dto.Isbn,
                Parution = dto.Parution,
                Format = dto.Format

            };
        }

    }
}
