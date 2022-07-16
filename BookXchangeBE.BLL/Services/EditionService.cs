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
    public class EditionService : IEditionService
    {
        private IEditionRepository editionRepository;

        public EditionService(IEditionRepository editionRepository)
        {
            this.editionRepository = editionRepository;
        }

        public IEnumerable<EditionDTO> GetAll()
        {

            return editionRepository.GetAll().Select(b => b.ToDTO());
        }

        public EditionDTO GetById(int id)
        {
            return editionRepository.GetById(id).ToDTO();
        }

        public IEnumerable<EditionDTO> GetByLivre(int id)
        {
            return editionRepository.GetAll().Where(c => c.IdEdition.Equals(id)).Select(b => b.ToDTO());
        }

        //public IEnumerable<LivreDTO> GetByYear(int year)
        //{
        //    return livreRepository.GetAll().Where(s => s.YearCar.Equals(year)).Select(b => b.ToDTO());
        //}

        public IEnumerable<EditionDTO> GetByIsbn(string isbn)
        {
            return editionRepository.GetAll().Where(m => m.Isbn.ToLower().Contains(isbn)).Select(b => b.ToDTO());
        }


        public bool Insert(EditionDTO H)
        {
            return editionRepository.Insert(H.ToEntity()) > 0;
        }

        public bool Update(int id, EditionDTO H)
        {
            return editionRepository.Update(id, H.ToEntity());
        }

        public bool Delete(int id)
        {
            return editionRepository.Delete(id);
        }

    }
}
