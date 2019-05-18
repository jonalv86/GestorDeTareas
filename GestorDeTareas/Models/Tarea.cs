//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorDeTareas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarea()
        {
            this.Comentarios = new HashSet<Comentario>();
        }
    
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> UsuarioAsignadoId { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public int UsuarioAltaId { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public Nullable<int> UsuarioBajaId { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public int PrioridadId { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Usuario UsuarioAlta { get; set; }
        public virtual Usuario UsuarioAsignado { get; set; }
        public virtual Usuario UsuarioBaja { get; set; }
        public virtual Prioridad Prioridad { get; set; }
        public virtual Estado Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
