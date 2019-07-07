using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Propietario
    {
        public Propietario()
        {
            Cancha = new HashSet<Cancha>();
        }

        public int Cpropietario { get; set; }

        public virtual Usuario CpropietarioNavigation { get; set; }
        public virtual ICollection<Cancha> Cancha { get; set; }
    }
}
