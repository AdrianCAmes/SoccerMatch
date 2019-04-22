using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public  class Usuario_Grupo
    {
        public int MCuota { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccionar un grupo")]
        [DisplayName("Seleccionar un grupo")]
        public Grupo CGrupo { get; set; }
        [Required(ErrorMessage = "Porfavor, seleccionar un usuario")]
        [DisplayName("Seleccionar un usuario")]
        public Usuario CDNI { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresar una fecha de pago")]
        [DisplayName("Ingresar una fecha de pago")]
        public string DFechaPago { get; set; }
    }
}
