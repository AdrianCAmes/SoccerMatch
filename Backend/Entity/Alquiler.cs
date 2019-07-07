using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Alquiler
    {
        public Alquiler()
        {
            DetalleParticipante = new HashSet<DetalleParticipante>();
        }

        public int Calquiler { get; set; }
        public int Cequipo { get; set; }
        public int Ccancha { get; set; }
        public DateTime DfechaInicio { get; set; }
        public DateTime DfechaRegistro{get;set;}
        public int NumHoras { get; set; }
        public decimal Mdescuento { get; set; }
        public decimal Mtotal { get; set; }
        public bool Fpagado { get; set; }

        public virtual Cancha CcanchaNavigation { get; set; }
        public virtual Equipo CequipoNavigation { get; set; }
        public virtual ICollection<DetalleParticipante> DetalleParticipante { get; set; }
    }
}
