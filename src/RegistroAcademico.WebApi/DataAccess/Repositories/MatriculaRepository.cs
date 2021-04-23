using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.DataAccess.Repositories
{
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }        
    }
}