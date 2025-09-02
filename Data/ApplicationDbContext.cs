using Microsoft.EntityFrameworkCore;
using AplicacionTodo_List_Rehacer.Models;

namespace AplicacionTodo_List_Rehacer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });

            // Configuración de Tarea
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Descripcion).HasMaxLength(1000);
                entity.Property(e => e.Estado).HasConversion<int>();
                entity.Property(e => e.Prioridad).HasConversion<int>();
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");

                // Relación con Usuario
                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Tareas)
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Datos de prueba con fechas estáticas
            var fechaBase = new DateTime(2025, 1, 1, 12, 0, 0);
            
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Usuario Demo",
                    Email = "demo@ejemplo.com",
                    FechaCreacion = fechaBase
                }
            );

            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    Id = 1,
                    Titulo = "Tarea de ejemplo - Por hacer",
                    Descripcion = "Esta es una tarea de ejemplo en estado 'Por hacer'",
                    Estado = EstadoTarea.PorHacer,
                    Prioridad = PrioridadTarea.Media,
                    UsuarioId = 1,
                    FechaCreacion = fechaBase
                },
                new Tarea
                {
                    Id = 2,
                    Titulo = "Tarea de ejemplo - En progreso",
                    Descripcion = "Esta es una tarea de ejemplo en estado 'En progreso'",
                    Estado = EstadoTarea.EnProgreso,
                    Prioridad = PrioridadTarea.Alta,
                    UsuarioId = 1,
                    FechaCreacion = fechaBase.AddHours(1)
                },
                new Tarea
                {
                    Id = 3,
                    Titulo = "Tarea de ejemplo - Completada",
                    Descripcion = "Esta es una tarea de ejemplo completada",
                    Estado = EstadoTarea.Completada,
                    Prioridad = PrioridadTarea.Baja,
                    UsuarioId = 1,
                    FechaCreacion = fechaBase.AddDays(-2),
                    FechaCompletada = fechaBase.AddDays(-1)
                }
            );
        }
    }
}