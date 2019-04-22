using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Cancha
    {
        public  int CCancha { get; set; }
        [Required(ErrorMessage = "Porfavor, ingrese un nombre de cancha")]
        [DisplayName("Ingresar nombre de cancha")]
        public string NCancha { get; set; }
        [Required(ErrorMessage = "Porfavor, ingrese una direccion")]
        [DisplayName("Ingrese una direccion")]
        public string TDireccion { get; set; }
        public int MPrecioHora { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione una calle")]
        [DisplayName("Seleccione una calle")]
        public Calle CCalle { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccione un propietario")]
        [DisplayName("Seleccione un propietario")]
        public Propietario CPropietario { get; set; }
}
}
