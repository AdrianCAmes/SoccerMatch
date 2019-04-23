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
        public int CDetalleParticipante { get; set; }
        [DisplayName("Codigo del alquiler")]
        [Required(ErrorMessage="Por favor, Ingrese el codigo del alquiler")]
        public Alquiler CAlquiler { get; set; }
        [DisplayName("Codigo del participante")]
        [Required(ErrorMessage ="Por favor ingrese el codigo del participante")]
        public Participante CParticipante { get; set; }
        [DisplayName("Cuota")]
        [Required(ErrorMessage = "Por favor, Ingrese la cuota")]
        public float MCuota { get; set; }
        [DisplayName("Estado de pago")]
        [Required(ErrorMessage ="Por favor, Ingrese el estado del pago")]
        public bool FPartePagada { get; set; }
    }
}
