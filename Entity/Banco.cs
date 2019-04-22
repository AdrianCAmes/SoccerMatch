using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Banco
    {
        public int CBanco { get; set; }
        [Required(ErrorMessage ="Porfavor, ingresar nombre de banco")]
        [DisplayName("Ingresar nombre de banco")]
        public string NBanco { get; set; }
       
    }
}
