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
        // Create
        int CreateExemplaire(ExemplaireDTO exemplaire);
        bool Insert(ExemplaireDTO exemplaire);
        
        // Read
        ExemplaireDTO GetById(int id);
        IEnumerable<ExemplaireDTO> GetAll();
        IEnumerable<ExemplaireDTO> GetByMembre(int id);
        IEnumerable<ExemplaireDTO> GetByLivre(int id);
        IEnumerable<ExemplaireDTO> GetByEdition(int id);

        // Update
        bool UpdateExemplaire(ExemplaireDTO exemplaire);
        bool Update(int id, ExemplaireDTO exemplaire);

        // Delete
        bool Delete(int id);
    }
}
