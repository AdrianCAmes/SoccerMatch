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

        public int CDistrito { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresa un distrito")]
        [DisplayName("Ingresa un distrito")]
        public string NDistrito { get; set; }
        [Required(ErrorMessage ="Porfavor, selecciona una ciudad")]
        [DisplayName("Selecciona una ciudad")]
        public Ciudad  CCiudad { get; set; }
        
    }
}
