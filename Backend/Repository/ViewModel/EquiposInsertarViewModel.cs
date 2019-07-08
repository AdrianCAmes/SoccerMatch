using System;

namespace Repository.ViewModel
{
    public class EquiposInsertarViewModel
    {
        public int Cequipo { get; set; }
        public string Nequipo { get; set; }
        public string Tdescripcion { get; set; }
        public int NumParticipantes { get; set; }
        public DateTime DfechaJuego { get; set; }
        public string Ndistrito { get; set; }
        public int idJugador {get; set; }
        public DateTime DfechaRegistro { get; set; }
    }
}