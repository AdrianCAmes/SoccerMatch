using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Jugador
    {
        public int CJugador { get; set; }
        [DisplayName("Calle")]
        [Required(ErrorMessage ="Por favor, Ingrese la calle")]
        public int CCalle { get; set; }
        [DisplayName("Direccion")]
        [Required(ErrorMessage = "Por favor, Ingrese la direccion")]
        public string TDireccion { get; set; }
    }
}
