using BookXchangeBE.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.Services
{
    public interface IMembreService
    {
        IEnumerable<MembreDTO> GetAll();
        IEnumerable<MembreDTO> GetByRole(int id);
        MembreDTO GetById(int id);
        MembreDTO GetByPseudo(string pseudo);

        bool CheckCredentials(string pseudo, string pwd);

        ConnectedMemberDTO ConnectMember(string pseudo, string password);

        MembreDTO Insert(string pseudo, string email, string pwd, int role);
        bool Update(int id, MembreDTO membre);

        bool Delete(int id);

    }
}
