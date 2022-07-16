using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.DAL.Entities
{
    public class EditionEntity
    {
        public int IdEdition { get; set; }
        public string Isbn { get; set; }
        public DateTime Parution { get; set; }
        public string Format { get; set; }

        public int IdLivre { get; set; }
    }
}
