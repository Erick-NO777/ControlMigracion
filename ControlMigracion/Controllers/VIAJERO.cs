//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlMigracion.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIAJERO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VIAJERO()
        {
            this.DOCUMENTOes = new HashSet<DOCUMENTO>();
            this.MOVIMIENTOS = new HashSet<MOVIMIENTO>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMIENTO> MOVIMIENTOS { get; set; }
    }
}