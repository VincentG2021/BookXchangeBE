using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;

namespace BookXchangeBE.API.Mappers
{
    public static class EditionMapper
    {
        public static ApiEditionModel ToModel(this EditionDTO dto)
        {
            return new ApiEditionModel()
            {
                IdEdition = dto.IdEdition,
                Isbn = dto.Isbn,
                Parution = dto.Parution,
                Format = dto.Format,
                IdLivre = dto.IdLivre,
            };
        }

        public static EditionDTO ToDTO(this ApiEditionModel edition)
        {
            return new EditionDTO()
            {
                IdEdition = edition.IdEdition,
                Isbn = edition.Isbn,
                Parution = edition.Parution,
                Format = edition.Format,
                IdLivre = edition.IdLivre,
            };
        }


    }
}
