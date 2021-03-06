﻿using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Cancha
    {
        public Cancha()
        {
            Alquiler = new HashSet<Alquiler>();
        }

        public int Ccancha { get; set; }
        public int Cpropietario { get; set; }
        public int Ccalle { get; set; }
        public string Ncancha { get; set; }
        public string Tdireccion { get; set; }
        public decimal MprecioHora { get; set; }

        public virtual Calle CcalleNavigation { get; set; }
        public virtual Propietario CpropietarioNavigation { get; set; }
        public virtual ICollection<Alquiler> Alquiler { get; set; }
    }
}
