using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Jugador : Usuario
    {
        [DisplayName("Calle")]
        [Required(ErrorMessage ="Por favor, ingrese una calle: ")]
        private int CCalle { get; set; }

        [DisplayName("Direccion")]
        [Required(ErrorMessage = "Por favor, ingrese una direccion")]
        private string TDireccion { get; set; }
    }
}
