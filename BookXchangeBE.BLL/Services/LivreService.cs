using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Mappers;
using BookXchangeBE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public class LivreService : ILivreService
    {
        private ILivreRepository livreRepository;

        public LivreService(ILivreRepository livreRepository)
        {
            this.livreRepository = livreRepository;
        }

        public IEnumerable<LivreDTO> GetAll()
        {

            return livreRepository.GetAll().Select(b => b.ToDTO());
        }

        public LivreDTO GetById(int id)
        {
            return livreRepository.GetById(id).ToDTO();
        }

        public IEnumerable<LivreDTO> GetByCategorie(int id)
        {
            return livreRepository.GetAll().Where(c => c.IdLivre.Equals(id)).Select(b => b.ToDTO());
        }

        //public IEnumerable<LivreDTO> GetByYear(int year)
        //{
        //    return livreRepository.GetAll().Where(s => s.YearCar.Equals(year)).Select(b => b.ToDTO());
        //}

        public IEnumerable<LivreDTO> GetByTitle(string titre)
        {
            return livreRepository.GetAll().Where(m => m.Titre.ToLower().Contains(titre)).Select(b => b.ToDTO());
        }


        public bool Insert(LivreDTO H)
        {
            return livreRepository.Insert(H.ToEntity()) > 0;
        }

        public bool Update(int id, LivreDTO H)
        {
            return livreRepository.Update(id, H.ToEntity());
        }

        public bool Delete(int id)
        {
            return livreRepository.Delete(id);
        }

    }
}
