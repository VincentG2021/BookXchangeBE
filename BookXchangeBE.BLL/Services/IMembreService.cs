﻿using BookXchangeBE.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public interface IMembreService
    {
        IEnumerable<ConnectedMemberDTO> GetAll();
        IEnumerable<MembreDTO> GetByRole(int id);
        ConnectedMemberDTO GetById(int id);
        MembreDTO GetByPseudo(string pseudo);
        bool CheckCredentials(string pseudo, string pwd);
        ConnectedMemberDTO ConnectMember(string pseudo, string password);
        ConnectedMemberDTO GetMemberProfile(string pseudo);
        MembreDTO Insert(string pseudo, string email, string pwd, int role);
        bool Update(int id, MembreDTO membre);
        bool Delete(int id);
        public bool UpdateConnectedMembre(int id, string image);
    }
}
