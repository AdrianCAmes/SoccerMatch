using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Equipo
    {
        public Equipo()
        {
            Alquiler = new HashSet<Alquiler>();
            Participante = new HashSet<Participante>();
        }

        public int Cequipo { get; set; }
        public string Nequipo { get; set; }
        public string Tdescripcion { get; set; }
        public int NumParticipantes { get; set; }
        public DateTime DfechaJuego { get; set; }
        public int Cdistrito { get; set; }
        public byte[] ImgFoto { get; set; }

        public virtual Distrito CdistritoNavigation { get; set; }
        public virtual ICollection<Alquiler> Alquiler { get; set; }
        public virtual ICollection<Participante> Participante { get; set; }
    }
}
