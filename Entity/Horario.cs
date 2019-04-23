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
        [DisplayName("Código de Horario")]
        private int CHorario { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese una hora de inicio: ")]
        [DisplayName("Hora de Inicio")]
        private DateTime DHoraInicial { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese una hora de fin: ")]
        [DisplayName("Hora de Fin")]
        private DateTime DHoraFinal { get; set; }
    }
}
