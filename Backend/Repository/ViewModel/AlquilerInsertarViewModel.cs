using System;
using System.Collections.Generic;
using Repository.ViewModel;

namespace Repository.ViewModel
{
    public class AlquilerInsertarViewModel
    {
        
        public int Calquiler { get; set; }
        public int Cequipo { get; set; }
        public string Ncancha { get; set; }
        public DateTime DfechaInicio { get; set; }
        public DateTime DfechaRegistro{get;set;}
        public int NumHoras { get; set; }
        public decimal Mdescuento { get; set; }
        public decimal Mtotal { get; set; }
        public bool Fpagado { get; set; }

        public IEnumerable<ParticipanteAlquierViewModel> participantes {get; set;}
    }
}