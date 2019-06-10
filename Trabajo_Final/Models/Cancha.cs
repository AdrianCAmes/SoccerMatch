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
        [DisplayName("Código de la Cancha")]
        public int CCancha { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione un propietario: ")]
        [DisplayName("Propietario")]
        public Propietario CPropietario { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione una calle: ")]
        [DisplayName("Calle")]
        public Calle CCalle { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese un nombre de cancha: ")]
        [DisplayName("Nombre de la Cancha")]
        public string NCancha { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese una direccion: ")]
        [DisplayName("Dirección")]
        public string TDireccion { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese un precio por hora: ")]
        [DisplayName("Precio x Hora")]
        public Decimal MPrecioHora { get; set;}
     
    }
}