using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Alquiler
    {
        [DisplayName("Código del Alquiler")]
        private int CAlquiler { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione grupo: ")]
        [DisplayName("Grupo")]
        private Grupo CGrupo { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione una cancha: ")]
        [DisplayName("Cancha")]
        private Cancha CCancha { get; set; }

        [DisplayName("Horas")]
        private int NumHoras { get; set; }

        [DisplayName("Descuento")]
        private float MDescuento { get; set; }

        [DisplayName("Total")]
        private float MTotal { get; set; }
        
        [DisplayName("Pagado")]
        private bool FPagado { get; set; }
       
        [Required(ErrorMessage ="Por favor, ingrese el horario: ")]
        [DisplayName("Horario")]
        private Horario CHorario { get; set; }
    }
}
