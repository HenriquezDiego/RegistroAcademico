using RegistroAcademico.WebApi.DataAccess.Repositories;

namespace RegistroAcademico.WebApi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IMateriaRepository Materias{get;}

        public IEstudianteRepository Estudiantes {get;}

        public IMatriculaRepository Matriculas {get;}

        public IAsistenciaRepository Asistencias {get;}

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Materias = new MateriaRepository(_appDbContext);
            Estudiantes = new EstudianteRepository(_appDbContext);
            Matriculas = new MatriculaRepository(_appDbContext);
            Asistencias = new AsistenciaRepository(_appDbContext);
        }

        public bool Complete()
        {
            return _appDbContext.SaveChanges() > 0;
        }
    }
}