using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.DataAccess.Repositories
{
    public class AsistenciaRepository : Repository<Asistencia>, IAsistenciaRepository
    {
        public AsistenciaRepository(AppDbContext appDbContext ) : base(appDbContext)
        {
            
        }
    }
}