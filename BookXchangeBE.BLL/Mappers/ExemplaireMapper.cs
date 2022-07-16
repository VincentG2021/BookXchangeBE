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
            };
        }

        public static ExemplaireEntity ToEntity(this ExemplaireDTO dto)
        {
            return new ExemplaireEntity()
            {
                IdEdition = dto.IdEdition,
                IdExemplaire = dto.IdExemplaire,
                IdMembre = dto.IdMembre,
            };
        }

    }
}
