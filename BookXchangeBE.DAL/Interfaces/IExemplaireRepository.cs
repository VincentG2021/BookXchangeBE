﻿using BookXchangeBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookXchangeBE.DAL.Interfaces
{
    public interface IExemplaireRepository : IRepository<int, ExemplaireEntity>
    {
    }
}
