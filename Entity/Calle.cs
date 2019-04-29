using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Calle
    {
        [DisplayName("Código de Calle")]
        public int CCalle { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese el nombre de calle: ")]
        [DisplayName("Nombre de Calle")]
        public string NCalle { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione un distrito: ")]
        [DisplayName("Distrito")]
        public Distrito CDistrito { get; set; }
    }
}
