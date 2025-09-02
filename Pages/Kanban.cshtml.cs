using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicacionTodo_List_Rehacer.Data;
using AplicacionTodo_List_Rehacer.ViewModels;
using AplicacionTodo_List_Rehacer.Models;

namespace AplicacionTodo_List_Rehacer.Pages
{
    public class KanbanModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public KanbanModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public KanbanViewModel KanbanBoard { get; set; } = new KanbanViewModel();

        public async Task OnGetAsync()
        {
            var tareas = await _context.Tareas
                .Include(t => t.Usuario)
                .OrderBy(t => t.FechaCreacion)
                .ToListAsync();

            KanbanBoard.TareasPorHacer = tareas.Where(t => t.Estado == EstadoTarea.PorHacer).ToList();
            KanbanBoard.TareasEnProgreso = tareas.Where(t => t.Estado == EstadoTarea.EnProgreso).ToList();
            KanbanBoard.TareasCompletadas = tareas.Where(t => t.Estado == EstadoTarea.Completada).ToList();
            KanbanBoard.Usuarios = await _context.Usuarios.ToListAsync();
        }

        public async Task<IActionResult> OnPostActualizarEstadoAsync(int id, EstadoTarea nuevoEstado)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            tarea.Estado = nuevoEstado;
            
            if (nuevoEstado == EstadoTarea.Completada)
            {
                tarea.FechaCompletada = DateTime.Now;
            }
            else
            {
                tarea.FechaCompletada = null;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEliminarTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}