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

        bool Insert(ExemplaireDTO edition);
        bool Update(int id, ExemplaireDTO edition);

        bool Delete(int id);

    }
}
