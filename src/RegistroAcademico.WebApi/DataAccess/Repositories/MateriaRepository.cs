using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.DataAccess.Repositories
{
    public class MateriaRepository : Repository<Materia>, IMateriaRepository
    {
        public MateriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}