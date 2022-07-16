using BookXchangeBE.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public interface IEditionService
    {
        IEnumerable<EditionDTO> GetAll();
        EditionDTO GetById(int id);

        IEnumerable<EditionDTO> GetByLivre(int id);

        IEnumerable<EditionDTO> GetByIsbn(string isbn);
        bool Insert(EditionDTO edition);
        bool Update(int id, EditionDTO edition);

        bool Delete(int id);

    }
}
