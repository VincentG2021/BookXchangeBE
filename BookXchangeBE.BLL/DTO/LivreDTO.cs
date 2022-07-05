using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.DTO
{
    public class LivreDTO
    {
        public int IdLivre { get; set; }
        public string Titre { get; set; }

        public string Auteur { get; set; }

        public string Synopsis { get; set; }

    }
}
