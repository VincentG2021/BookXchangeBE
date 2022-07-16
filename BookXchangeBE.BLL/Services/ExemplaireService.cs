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

        public bool Insert(ExemplaireDTO H)
        {
            return exemplaireRepository.Insert(H.ToEntity()) > 0;
        }

        public bool Update(int id, ExemplaireDTO H)
        {
            return exemplaireRepository.Update(id, H.ToEntity());
        }

        public bool Delete(int id)
        {
            return exemplaireRepository.Delete(id);
        }

    }
}
