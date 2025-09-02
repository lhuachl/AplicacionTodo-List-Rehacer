using AplicacionTodo_List_Rehacer.Models;

namespace AplicacionTodo_List_Rehacer.ViewModels
{
    public class KanbanViewModel
    {
        public List<Tarea> TareasPorHacer { get; set; } = new List<Tarea>();
        public List<Tarea> TareasEnProgreso { get; set; } = new List<Tarea>();
        public List<Tarea> TareasCompletadas { get; set; } = new List<Tarea>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}