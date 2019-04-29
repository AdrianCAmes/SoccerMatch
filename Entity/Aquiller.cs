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
        public int CAlquiler { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione grupo: ")]
        [DisplayName("Grupo")]
        public Grupo CGrupo { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione una cancha: ")]
        [DisplayName("Cancha")]
        public Cancha CCancha { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione una hora de inicio: ")]
        [DisplayName("Hora de Incio")]
        public DateTime DHoraInicio { get; set; }

        [DisplayName("Horas")]
        public int NumHoras { get; set; }

        [DisplayName("Descuento")]
        public Decimal MDescuento { get; set; }

        [DisplayName("Total")]
        public Decimal MTotal { get; set; }

        [DisplayName("Pagado")]
        public bool FPagado { get; set; }
    }
}
