using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Participante
    {
        [DisplayName("Código de Participante")]
        private int CParticipante { get; set; }

        [DisplayName("Jugador")]
        [Required(ErrorMessage ="Por favor, ingrese el jugador")]
        private Jugador CJugador { get; set; }

        [DisplayName("Grupo")]
        [Required(ErrorMessage ="Por favor, ingrese el grupo")]
        private Grupo CGrupo { get; set; }

    }
}
