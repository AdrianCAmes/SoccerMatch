using System;
using System.Collections.Generic;

namespace SoccerMatch_TF.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Distrito = new HashSet<Distrito>();
        }

        public int Cciudad { get; set; }
        public string Nciudad { get; set; }
        public int Cdepartamento { get; set; }

        public virtual Departamento CdepartamentoNavigation { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
    }
}
