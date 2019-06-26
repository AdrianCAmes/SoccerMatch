using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Participante
    {
        public Participante()
        {
            DetalleParticipante = new HashSet<DetalleParticipante>();
        }

        public int Cparticipante { get; set; }
        public int Cjugador { get; set; }
        public int Cequipo { get; set; }
        public bool FesAdministrador { get; set; }

        public virtual Equipo CequipoNavigation { get; set; }
        public virtual Jugador CjugadorNavigation { get; set; }
        public virtual ICollection<DetalleParticipante> DetalleParticipante { get; set; }
    }
}
