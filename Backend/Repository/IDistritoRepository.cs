﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Repository
{
    public interface IDistritoRepository : ICrudRepository<Distrito>
    {
        IEnumerable<string> GetAllNames();
    }
}
