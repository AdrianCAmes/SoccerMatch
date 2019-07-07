using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
    public class EquiposRecomendadosViewModel
    {
        public int Id { get; set; }
        public int idEquipo{get;set;}
        public string NombreEquipo { get; set; }
        public string NombreDistrito { get; set; }
        public int  CantidadVacantes { get; set; }
        public DateTime fechaJuego { get; set; }

}
}
