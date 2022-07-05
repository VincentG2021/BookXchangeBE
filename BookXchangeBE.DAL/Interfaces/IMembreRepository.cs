using BookXchangeBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.DAL.Interfaces
{
    public interface IMembreRepository : IRepository<int, MembreEntity>
    {
        bool CheckMemberExists(string pseudo, string email);
        string GetPasswordHash(string pseudo);
        MembreEntity GetByPseudo(string pseudo);
    }
}
