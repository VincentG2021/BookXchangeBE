using BookXchangeBE.BLL.DTO;
using BookXchangeBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Mappers
{
    internal static class MembreMapper
    {
        public static MembreDTO ToDTO(this MembreEntity entity)
        {
            return new MembreDTO()
            {
                IdMembre = entity.IdMembre,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                Prenom = entity.Prenom,
                Nom = entity.Nom,
                PwdHash = entity.PwdHash,
                Role = entity.Role
            };
        }

        public static MembreEntity ToEntity(this MembreDTO dto)
        {
            return new MembreEntity()
            {
                IdMembre = dto.IdMembre,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                PwdHash = dto.PwdHash,
                Role = dto.Role
            };
        }

        public static ConnectedMemberDTO CMToDTO(this MembreEntity entity)
        {
            return new ConnectedMemberDTO()
            {
                IdMembre = entity.IdMembre,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                Prenom = entity.Prenom,
                Nom = entity.Nom,
                Role = entity.Role
            };
        }
    }
}
