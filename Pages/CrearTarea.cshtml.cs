using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicacionTodo_List_Rehacer.Data;
using AplicacionTodo_List_Rehacer.ViewModels;
using AplicacionTodo_List_Rehacer.Models;

namespace AplicacionTodo_List_Rehacer.Pages
{
    public class CrearTareaModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearTareaModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearTareaViewModel NuevaTarea { get; set; } = new CrearTareaViewModel();

        public async Task OnGetAsync()
        {
            NuevaTarea.Usuarios = await _context.Usuarios.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                NuevaTarea.Usuarios = await _context.Usuarios.ToListAsync();
                return Page();
            }

            var tarea = new Tarea
            {
                Titulo = NuevaTarea.Titulo,
                Descripcion = NuevaTarea.Descripcion,
                Prioridad = NuevaTarea.Prioridad,
                FechaVencimiento = NuevaTarea.FechaVencimiento,
                UsuarioId = NuevaTarea.UsuarioId,
                Estado = EstadoTarea.PorHacer,
                FechaCreacion = DateTime.Now
            };

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Kanban");
        }
    }
}