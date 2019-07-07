using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Usuario
    {
        public int Cusuario { get; set; }
        public long Cdni { get; set; }
        public string Nusuario { get; set; }
        public long NumTelefono { get; set; }
        public string Usuario1 { get; set; }
        public string Pswd { get; set; }

        public virtual Jugador Jugador { get; set; }
        public virtual Propietario Propietario { get; set; }
    }
}
