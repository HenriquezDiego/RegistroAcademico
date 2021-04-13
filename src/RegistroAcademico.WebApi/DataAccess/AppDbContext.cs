using Microsoft.EntityFrameworkCore;
using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}