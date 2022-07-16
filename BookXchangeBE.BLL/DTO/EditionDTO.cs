using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.BLL.DTO
{
    public class EditionDTO : LivreDTO
    {
        public int IdEdition { get; set; }
        public string Isbn { get; set; }
        public DateTime Parution { get; set; }
        public string Format { get; set; }
        public int IdLivre { get; set; }

    }
}
