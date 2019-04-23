using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        public long CDNI { get; set; }
        [Required(ErrorMessage ="Porfavor, ingresar un nombre de usuario")]
    [DisplayName("Ingresar un nombre de usuario")]
        public string NUsuario { get; set; }
        public int CCalle { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresar una direccion")]
        [DisplayName("Ingresar una direccion")]
        public string TDireccion { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresar un numero de telefono")]
        [DisplayName("Ingresar un numero de telefono")]
        public string NTelefono { get; set; }

    
    }
}
