using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class Grupo
    {

        public int CGrupo { get; set; }
        [Required(ErrorMessage ="Porfavor, ingresar nombre de grupo")]
        [DisplayName("Ingresar nombre de grupo")]
        public string NGrupo { get; set; }
        [DisplayName("Ingresar descripcion")]
        public string TDescripcion { get; set; }
        public int NumParticipantes { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresar una fecha de juego")]
        [DisplayName("Ingresar una fecha de juego")]
        public string DFechaJuego { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccionar un distrito")]
        [DisplayName("Seleccionar un distrito")]
        public Distrito CDistrito { get; set; }

}
}
