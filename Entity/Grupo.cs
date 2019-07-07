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
        [DisplayName("Código de Grupo")]
        public int CGrupo { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese el nombre del grupo: ")]
        [DisplayName("Nombre de Grupo")]
        public string NGrupo { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese la descripcion del grupo: ")]
        [DisplayName("Descripcion")]
        public string TDescripcion { get; set; }

        public int NumParticipantes { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese una fecha de juego: ")]
        [DisplayName("Fecha de Juego")]
        [DataType(DataType.Date)]
        public DateTime DFechaJuego { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccion un distrito: ")]
        [DisplayName("Distrito")]
        public Distrito CDistrito { get; set; }

    }
}
