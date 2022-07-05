using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;

namespace BookXchangeBE.API.Mappers
{
    internal static class LivreMapper
    {
        public static ApiLivreModel ToModel(this LivreDTO dto)
        {
            return new ApiLivreModel()
            {
                IdLivre = dto.IdLivre,
                Titre = dto.Titre,
                Auteur = dto.Auteur,
                Synopsis = dto.Synopsis,
            };
        }

        public static LivreDTO ToDTO(this ApiLivreModel livre)
        {
            return new LivreDTO()
            {
                IdLivre = livre.IdLivre,
                Titre = livre.Titre,
                Auteur = livre.Auteur,
                Synopsis = livre.Synopsis,
            };
        }
    }
}
