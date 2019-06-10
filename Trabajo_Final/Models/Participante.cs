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
        public int CParticipante { get; set; }

        [DisplayName("Jugador")]
        [Required(ErrorMessage = "Por favor, ingrese el jugador")]
        public Jugador CJugador { get; set; }

        [DisplayName("Grupo")]
        [Required(ErrorMessage = "Por favor, ingrese el grupo")]
        public Grupo CGrupo { get; set; }

        [DisplayName("Es Administrador")]
        [Required(ErrorMessage = "Por favor, especifique si es administrador")]
        public bool FEsAdministrador { get; set; }

    }
}
