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
        public  int CCalle { get; set; }
        [Required(ErrorMessage ="Porfavor, ingresar el nombre de calle")]
        [DisplayName("Ingresar nombre de calle")]
        public string NCalle { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccionar un distrito")]
        [DisplayName("Seleccionar un distrito")]
        public Distrito CDistrito { get; set; }
    }
}
