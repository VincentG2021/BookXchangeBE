using BookXchangeBE.BLL.DTO;

namespace BookXchangeBE.Models.Mappers
{
    internal static class MembreMapper
    {
        public static Membre ToModel(this MembreDTO dto)
        {
            return new Membre()
            {
                IdMembre = dto.IdMembre,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                Role = dto.Role
            };
        }
    }
}
