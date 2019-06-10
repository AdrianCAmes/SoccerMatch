using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Ciudad
    {
        [DisplayName("Código de la Ciudad")]
        public int CCiudad { get; set; }

        [Required(ErrorMessage = "Porfavor, ingrese un nombre de ciudad: ")]
        [DisplayName("Nombre de la Ciudad")]
        public string NCiudad { get; set; }

        [Required(ErrorMessage = "Porfavor, seleccione un departamento: ")]
        [DisplayName("Departamento")]
        public Departamento CDepartamento { get; set; }

    }
}
