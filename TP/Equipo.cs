//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            this.Alquiler = new HashSet<Alquiler>();
            this.Participante = new HashSet<Participante>();
        }
    
        public int CEquipo { get; set; }
        public string NEquipo { get; set; }
        public string TDescripcion { get; set; }
        public int NumParticipantes { get; set; }
        public System.DateTime DFechaJuego { get; set; }
        public int CDistrito { get; set; }
        public byte[] ImgFoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alquiler> Alquiler { get; set; }
        public virtual Distrito Distrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participante> Participante { get; set; }
    }
}
