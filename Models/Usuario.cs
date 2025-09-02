using System.ComponentModel.DataAnnotations;

namespace AplicacionTodo_List_Rehacer.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        // Relación con tareas
        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}