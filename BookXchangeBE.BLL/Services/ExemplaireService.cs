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
    public class ExemplaireService : IExemplaireService
    {
        private IExemplaireRepository exemplaireRepository;

        public ExemplaireService(IExemplaireRepository exemplaireRepository)
        {
            this.exemplaireRepository = exemplaireRepository;
        }

        public IEnumerable<ExemplaireDTO> GetAll()
        {

            return exemplaireRepository.GetAll().Select(b => b.ToDTO());
        }

        public ExemplaireDTO GetById(int id)
        {
            return exemplaireRepository.GetById(id).ToDTO();
        }

        public IEnumerable<ExemplaireDTO> GetByMembre(int id)
        {
            //return exemplaireRepository.GetAll().Where(c => c.IdMembre.Equals(id)).Select(b => b.ToDTO());
            return exemplaireRepository.GetByMembre(id).Where(c => c.IdMembre.Equals(id)).Select(b => b.ToDTO());

        }

        public IEnumerable<ExemplaireDTO> GetByEdition(int id)
        {
            return exemplaireRepository.GetByEdition(id).Select(b => b.ToDTO());
        }

        public IEnumerable<ExemplaireDTO> GetByLivre(int id)
        {
            return exemplaireRepository.GetByLivre(id).Select(b => b.ToDTO());
        }

        public int CreateExemplaire(ExemplaireDTO E)
        {
            return exemplaireRepository.CreateExemplaire(E.ToEntity());
        }

        public bool Insert(ExemplaireDTO E)
        {
            return exemplaireRepository.Insert(E.ToEntity()) > 0;
        }

        public bool Update(int id, ExemplaireDTO E)
        {
            return exemplaireRepository.Update(id, E.ToEntity());
        }

        public bool Delete(int id)
        {
            return exemplaireRepository.Delete(id);
        }

    }
}
