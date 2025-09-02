using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicacionTodo_List_Rehacer.Data;
using AplicacionTodo_List_Rehacer.Models;

namespace AplicacionTodo_List_Rehacer.Pages
{
    public class UsuariosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UsuariosModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuarios { get; set; } = new List<Usuario>();

        [BindProperty]
        public Usuario NuevoUsuario { get; set; } = new Usuario();

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios
                .Include(u => u.Tareas)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCrearAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.Usuarios.Add(NuevoUsuario);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}