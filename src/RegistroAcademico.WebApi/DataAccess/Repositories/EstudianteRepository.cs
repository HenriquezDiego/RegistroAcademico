using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.DataAccess.Repositories
{
    public class EstudianteRepository : Repository<Estudiante>, IEstudianteRepository
    {
        public EstudianteRepository(AppDbContext context) : base(context)
        {
        }
    }
}