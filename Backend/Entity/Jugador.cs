using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Jugador
    {
        public Jugador()
        {
            Participante = new HashSet<Participante>();
        }

        public int Cjugador { get; set; }
        public string Tdireccion { get; set; }

        public virtual Usuario CjugadorNavigation { get; set; }
        public virtual ICollection<Participante> Participante { get; set; }
    }
}
