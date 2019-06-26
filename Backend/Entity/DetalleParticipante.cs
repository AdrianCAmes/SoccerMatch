using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class DetalleParticipante
    {
        public int CdetalleParticipante { get; set; }
        public int Calquiler { get; set; }
        public int Cparticipante { get; set; }
        public decimal Mcuota { get; set; }
        public bool FpartePagada { get; set; }
        public int Ncupos { get; set; }

        public virtual Alquiler CalquilerNavigation { get; set; }
        public virtual Participante CparticipanteNavigation { get; set; }
    }
}
