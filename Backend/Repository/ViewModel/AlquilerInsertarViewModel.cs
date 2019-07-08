using System;
using System.Collections.Generic;
using Repository.ViewModel;
using Entity;

namespace Repository.ViewModel
{
    public class AlquilerInsertarViewModel
    {
        public int Calquiler { get; set; }
        public int Cequipo { get; set; }
        public IEnumerable<Cancha> canchas { get; set; }
        public DateTime DfechaInicio { get; set; }
        public DateTime DfechaRegistro{get;set;}
        public int NumHoras { get; set; }

        public IEnumerable<Participante> participantes {get; set;}
    }
}