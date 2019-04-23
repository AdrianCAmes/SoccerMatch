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
        public int CParticipante { get; set; }
        [DisplayName("Jugador")]
        [Required(ErrorMessage ="Por favor, Ingrese el jugador")]
        public Jugador CJugador { get; set; }
        [DisplayName("Grupo")]
        [Required(ErrorMessage ="Por favor, ingrese el grupo")]
        public Grupo CGrupo { get; set; }

    }
}
