using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Tarjeta
    {
        public long NumTarjeta { get; set; }
        public int NumCodigoSeguridad { get; set; }
        public string NTitular { get; set; }
        [Required(ErrorMessage ="Porfavor, elegir un banco")]
        [DisplayName("Seleccionar un banco")]
        public Banco CBanco { get; set; }

    }
}
