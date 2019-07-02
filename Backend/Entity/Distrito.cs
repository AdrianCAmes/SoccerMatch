using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Distrito
    {
        public Distrito()
        {
            Calle = new HashSet<Calle>();
            Equipo = new HashSet<Equipo>();
        }

        public int Cdistrito { get; set; }
        public string Ndistrito { get; set; }
        public int Cciudad { get; set; }

        public virtual Ciudad CciudadNavigation { get; set; }
        public virtual ICollection<Calle> Calle { get; set; }
        public virtual ICollection<Equipo> Equipo { get; set; }
    }
}
