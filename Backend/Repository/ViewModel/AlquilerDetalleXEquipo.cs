using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
    public class AlquilerDetalleXEquipo
    {
        public int calquiler { get; set; }
            public int cequipo { get; set; }
        public int cdistrito { get; set; }
        public int ccancha { get; set; }

        public DateTime fInicio { get; set; }
        public string ncancha { get; set; }
        public string tdireccion{ get; set; }
        public string ndistrito { get; set; }
        public int numparticipantes { get; set; }
        public int numhoras { get; set; }



    }
}
