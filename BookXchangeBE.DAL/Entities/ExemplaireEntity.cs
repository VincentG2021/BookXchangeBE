using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.DAL.Entities
{
    public class ExemplaireEntity : EditionEntity
    {
        public int IdExemplaire { get; set; }
        public int IdMembre { get; set; }
        public int IdEdition { get; set; }


        //public int IdLivre { get; set; }
        //public string Titre { get; set; }

        //public string Auteur { get; set; }

        //public string Synopsis { get; set; }


        //public string Isbn { get; set; }
        //public DateTime Parution { get; set; }
        //public string Format { get; set; }

    }
}
