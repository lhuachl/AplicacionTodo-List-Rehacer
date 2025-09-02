using System.ComponentModel.DataAnnotations;
using AplicacionTodo_List_Rehacer.Models;

namespace AplicacionTodo_List_Rehacer.ViewModels
{
    public class CrearTareaViewModel
    {
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string Titulo { get; set; } = string.Empty;
        
        [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "La prioridad es requerida")]
        public PrioridadTarea Prioridad { get; set; } = PrioridadTarea.Media;
        
        public DateTime? FechaVencimiento { get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar un usuario")]
        public int UsuarioId { get; set; }
        
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}