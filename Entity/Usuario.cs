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
        protected int CUsuario { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese el DNI del usuario")]
        [DisplayName("DNI")]
        protected long CDNI { get; set; }

        [Required(ErrorMessage ="Porfavor, ingrese un nombre de usuario")]
        [DisplayName("Nombre de Usuario")]
        protected string NUsuario { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese un numero de telefono")]
        [DisplayName("Numero de Telefono")]
        protected long NumTelefono { get; set; }

    
    }
}
