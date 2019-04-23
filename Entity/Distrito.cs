using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Distrito
    {
        [DisplayName("Codigo del Distrito")]
        public int CDistrito { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese un distrito: ")]
        [DisplayName("Nombre del Distrito")]
        public string NDistrito { get; set; }

        [Required(ErrorMessage ="Porfavor, seleccione una ciudad: ")]
        [DisplayName("Ciudad")]
        public Ciudad  CCiudad { get; set; }
        
    }
}
