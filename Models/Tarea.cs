using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionTodo_List_Rehacer.Models
{
    public enum EstadoTarea
    {
        PorHacer = 1,
        EnProgreso = 2,
        Completada = 3
    }

    public enum PrioridadTarea
    {
        Baja = 1,
        Media = 2,
        Alta = 3,
        Urgente = 4
    }

    public class Tarea
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Descripcion { get; set; }
        
        [Required]
        public EstadoTarea Estado { get; set; } = EstadoTarea.PorHacer;
        
        [Required]
        public PrioridadTarea Prioridad { get; set; } = PrioridadTarea.Media;
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public DateTime? FechaVencimiento { get; set; }
        
        public DateTime? FechaCompletada { get; set; }
        
        // Relación con Usuario
        [Required]
        public int UsuarioId { get; set; }
        
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;
    }
}