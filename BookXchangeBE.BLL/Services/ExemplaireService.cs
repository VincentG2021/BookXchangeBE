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
        private IExemplaireRepository _exemplaireRepository;

        public ExemplaireService(IExemplaireRepository exemplaireRepository)
        {
            _exemplaireRepository = exemplaireRepository;
        }

        // Create
        public int CreateExemplaire(ExemplaireDTO E)
        {
            return _exemplaireRepository.CreateExemplaire(E.ToEntity());
        }
        public bool Insert(ExemplaireDTO E)
        {
            return _exemplaireRepository.Insert(E.ToEntity()) > 0;
        }

        // Read
        public ExemplaireDTO GetById(int id)
        {
            return _exemplaireRepository.GetById(id).ToDTO();
        }

        public IEnumerable<ExemplaireDTO> GetAll()
        {
            return _exemplaireRepository.GetAll().Select(b => b.ToDTO());
        }

        public IEnumerable<ExemplaireDTO> GetByMembre(int id)
        {
            //return exemplaireRepository.GetAll().Where(c => c.IdMembre.Equals(id)).Select(b => b.ToDTO());
            return _exemplaireRepository.GetByMembre(id).Where(c => c.IdMembre.Equals(id)).Select(b => b.ToDTO());
        }
        public IEnumerable<ExemplaireDTO> GetByLivre(int id)
        {
            return _exemplaireRepository.GetByLivre(id).Select(b => b.ToDTO());
        }

        public IEnumerable<ExemplaireDTO> GetByEdition(int id)
        {
            return _exemplaireRepository.GetByEdition(id).Select(b => b.ToDTO());
        }

        // Update
        public bool UpdateExemplaire(ExemplaireDTO E)
        {
            return _exemplaireRepository.UpdateExemplaire(E.ToEntity());
        }

        public bool Update(int id, ExemplaireDTO E)
        {
            return _exemplaireRepository.Update(id, E.ToEntity());
        }

        // Delete
        public bool Delete(int id)
        {
            return _exemplaireRepository.Delete(id);
        }
    }
}
