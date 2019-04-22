using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Horario
    {
        public int CHorario { get; set; }
        [Required(ErrorMessage = "Porfavor, ingrese una hora de iniciacion")]
        [DisplayName("Ingrese una hora de iniciacion")]
        public string DHoraInicial { get; set; }
        [Required(ErrorMessage = "Porfavor, ingrese una hora de finalizacion")]
        [DisplayName("Ingrese una hora de finalizacion")]
        public string DHoraFinal { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccione un dia")]
        [DisplayName("Seleccione un dia")]
        public Dia CDia { get; set; }
        [Required(ErrorMessage = "Porfavor, ingrese un nombre para la cancha")]
        [DisplayName("Ingresar un nombre para la cancha")]
        public Cancha CCancha { get; set; }
    }
}
