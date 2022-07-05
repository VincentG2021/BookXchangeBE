using BookXchangeBE.BLL.DTO;

namespace BookXchangeBE.Models.Mappers
{
    internal static class LivreMapper
    {
        public static Livre ToModel(this LivreDTO dto)
        {
            return new Livre()
            {
                IdLivre = dto.IdLivre,
                Titre = dto.Titre,
                Auteur = dto.Auteur,
                Synopsis = dto.Synopsis,
            };
        }

        public static LivreDTO ToDTO(this Livre livre)
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
