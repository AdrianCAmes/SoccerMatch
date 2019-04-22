using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
  public   class Propietario
    {
        public int CPropietario { get; set; }
        [Required(ErrorMessage = "Porfavor, ingresar nombre de propietario")]
        [DisplayName("Ingresar nombre de propietario")]
        public string NPropietario { get; set; }

    }
}
