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
       int CAlquiler { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccionar grupo")]
        [DisplayName("Grupo")]
        Grupo CGrupo { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresar fecha de alquiler")]
        [DisplayName("Fecha de alquiler")]
        string DFechaAlquiler { get; set; }
        int Num_Horas { get; set; }
        int MDescuento { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccionar una cancha")]
        [DisplayName("Cancha")]
        Cancha CCancha { get; set; }
        [Required(ErrorMessage ="Por favor, ingrese el horario")]
        [DisplayName("Horario")]
        Horario CHorario { get; set; }
    }
}
