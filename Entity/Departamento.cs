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
        [DisplayName("Código del Departamento")]
        private int CDepartamento { get; set; }

        [Required(ErrorMessage ="Porfavor, ingrese el nombre de departamento: ")]
        [DisplayName("Nombre del Departamento")]
        private string NDepartamento { get; set; }
    }
}
