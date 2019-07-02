using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Departamento
    {
        public Departamento()
        {
            Ciudad = new HashSet<Ciudad>();
        }

        public int Cdepartamento { get; set; }
        public string Ndepartamento { get; set; }

        public virtual ICollection<Ciudad> Ciudad { get; set; }
    }
}
