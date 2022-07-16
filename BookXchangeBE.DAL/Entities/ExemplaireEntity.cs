using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.DAL.Entities
{
    public class ExemplaireEntity
    {
        public int IdExemplaire { get; set; }
        public int IdMembre { get; set; }
        public int IdEdition { get; set; }
    }
}
