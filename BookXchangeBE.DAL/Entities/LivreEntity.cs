﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.DAL.Entities
{
    public class LivreEntity
    {
        public int IdLivre { get; set; }
        public string Titre { get; set; }

        public string Auteur { get; set; }

        public string Synopsis { get; set; }
    }
}
