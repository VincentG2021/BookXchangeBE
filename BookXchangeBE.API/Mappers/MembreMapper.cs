using BookXchangeBE.API.Models;
using BookXchangeBE.BLL.DTO;

namespace BookXchangeBE.API.Mappers
{
    public static class MembreMapper
    {
        public static ApiMembreModel ToAPI(this MembreDTO dto)
        {
            return new ApiMembreModel()
            {
                IdMembre = dto.IdMembre,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                Role = dto.Role
            };
        }

        public static ApiConnectedMembreModel ToApiConnected(this ConnectedMemberDTO dto)
        {
            return new ApiConnectedMembreModel()
            {
                IdMembre = dto.IdMembre,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                Role = dto.Role,
                Token = dto.Token,
                Localisation = dto.Localisation,
                Image = dto.Image
            };
        }

        public static MembreDTO ToDTO(this ApiMembreModel membre)
        {
            return new MembreDTO()
            {
                IdMembre = membre.IdMembre,
                Pseudo = membre.Pseudo,
                Email = membre.Email,
                Prenom = membre.Prenom,
                Nom = membre.Nom,
                Role = membre.Role
            };
        }
    }
}
