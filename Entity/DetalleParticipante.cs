using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class DetalleParticipante
    {
        [DisplayName("Código del Detalle")]
        private int CDetalleParticipante { get; set; }

        [Required(ErrorMessage="Por favor, ingrese el codigo del alquiler: ")]
        [DisplayName("Alquiler")]
        private Alquiler CAlquiler { get; set; }

        [Required(ErrorMessage ="Por favor, ingrese el codigo del participante: ")]
        [DisplayName("Participante")]
        private Participante CParticipante { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la cuota: ")]
        [DisplayName("Cuota")]
        private float MCuota { get; set; }

        [Required(ErrorMessage ="Por favor, ingrese el estado del pago: ")]
        [DisplayName("Estado de Pago")]
        private bool FPartePagada { get; set; }
    }
}
