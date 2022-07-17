using BookXchangeBE.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public interface ILivreService
    {
        IEnumerable<LivreDTO> GetAll();
        LivreDTO GetById(int id);

        IEnumerable<LivreDTO> GetByCategorie(int id);

        IEnumerable<LivreDTO> GetByTitle(string titre);
        LivreDTO Insert(string Titre, string Auteur, string Synopsis);
        bool Update(int id, LivreDTO livre);

        bool Delete(int id);
    }
}
