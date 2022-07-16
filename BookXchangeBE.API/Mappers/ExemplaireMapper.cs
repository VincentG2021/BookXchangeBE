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
                IdExemplaire = dto.IdExemplaire,
                IdEdition = dto.IdEdition,
                IdMembre = dto.IdMembre,
            };
        }

        public static ExemplaireDTO ToDTO(this ApiExemplaireModel exemplaire)
        {
            return new ExemplaireDTO()
            {
                IdExemplaire = exemplaire.IdExemplaire,
                IdEdition = exemplaire.IdEdition,
                IdMembre = exemplaire.IdMembre,
            };
        }

    }
}
