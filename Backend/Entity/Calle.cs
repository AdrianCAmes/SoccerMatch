using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Calle
    {
        public Calle()
        {
            Cancha = new HashSet<Cancha>();
        }

        public int Ccalle { get; set; }
        public string Ncalle { get; set; }
        public int Cdistrito { get; set; }

        public virtual Distrito CdistritoNavigation { get; set; }
        public virtual ICollection<Cancha> Cancha { get; set; }
    }
}
