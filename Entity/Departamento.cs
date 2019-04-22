using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Departamento
    {

        public int CDepartamento { get; set; }
        [Required(ErrorMessage ="Porfavor, ingresar nombre de departamento")]
        [DisplayName("Ingresar nombre de departamento")]
        public string NDepartamento { get; set; }
    }
}
