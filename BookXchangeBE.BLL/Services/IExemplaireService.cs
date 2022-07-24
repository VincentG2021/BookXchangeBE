using BookXchangeBE.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public interface IExemplaireService
    {
        IEnumerable<ExemplaireDTO> GetAll();
        ExemplaireDTO GetById(int id);
        IEnumerable<ExemplaireDTO> GetByMembre(int id);
        IEnumerable<ExemplaireDTO> GetByEdition(int id);
        IEnumerable<ExemplaireDTO> GetByLivre(int id);

        int CreateExemplaire(ExemplaireDTO exemplaire);
        bool Insert(ExemplaireDTO exemplaire);
        bool Update(int id, ExemplaireDTO exemplaire);
        bool Delete(int id);

    }
}
