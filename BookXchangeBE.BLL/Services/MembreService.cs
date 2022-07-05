using BookXchangeBE.BLL.DTO;
using BookXchangeBE.BLL.Mappers;
using BookXchangeBE.DAL.Entities;
using BookXchangeBE.DAL.Interfaces;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public class MembreService : IMembreService
    {
        private IMembreRepository membreRepository;

        public MembreService(IMembreRepository membreRepository)
        {
            this.membreRepository = membreRepository;
        }

        #region Register & Login


        public MembreDTO Insert(string pseudo, string email, string pwd, int role)
        {
            int id = membreRepository.Insert(new MembreEntity
            {
                Pseudo = pseudo,
                Email = email,
                PwdHash = Argon2.Hash(pwd)         // Hashage du mot de passe          
,
                Role = role
            });

            return membreRepository.GetById(id).ToDTO();
        }

        public bool CheckCredentials(string pseudo, string pwd)
        {
            string pwdHash = membreRepository.GetPasswordHash(pseudo);
            if (pwdHash is null)
            {
                return false;
            }

            return Argon2.Verify(pwdHash, pwd);
        }

        public bool CheckMemberExists(string pseudo, string email)
        {
            return membreRepository.CheckMemberExists(pseudo, email);
        }
        #endregion


        #region Crud
        public IEnumerable<MembreDTO> GetAll()
        {
            return membreRepository.GetAll().Select(b => b.ToDTO());
        }

        public IEnumerable<MembreDTO> GetByRole(int id)
        {
            throw new NotImplementedException();
        }

        public MembreDTO GetByPseudo(string pseudo)
        {
            return membreRepository.GetByPseudo(pseudo).ToDTO();
        }

        public MembreDTO GetById(int id)
        {
            throw new NotImplementedException();
        }



        public bool Update(int id, MembreDTO membre)
        {
            return membreRepository.Update(id, membre.ToEntity());
        }

        public bool Delete(int idMember)
        {
            return membreRepository.Delete(idMember);
        }

        #endregion
    }
}
