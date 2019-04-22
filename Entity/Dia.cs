using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Dia
    {
        public int CDia { get; set; }
        [Required(ErrorMessage = "Porfavor, ingrese un nombre de dia")]
        [DisplayName("Ingrese un nombre de dia")]
        public string NDia { get; set; }
}
}
