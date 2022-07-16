using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;

namespace BookXchangeBE.API.Mappers
{
    internal static class ExemplaireMapper
    {
        public static ApiExemplaireModel ToModel(this ExemplaireDTO dto)
        {
            return new ApiExemplaireModel()
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

        public static ExemplaireDTO ToDTO(this ApiExemplaireModel exemplaire)
        {
            return new ExemplaireDTO()
            {
                IdExemplaire = exemplaire.IdExemplaire,
                IdEdition = exemplaire.IdEdition,
                IdMembre = exemplaire.IdMembre,

                IdLivre = exemplaire.IdLivre,
                Titre = exemplaire.Titre,
                Auteur = exemplaire.Auteur,
                Synopsis = exemplaire.Synopsis,

                Isbn = exemplaire.Isbn,
                Parution = exemplaire.Parution,
                Format = exemplaire.Format
            };
        }

    }
}
