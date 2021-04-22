using RegistroAcademico.WebApi.DataAccess.Repositories;

namespace RegistroAcademico.WebApi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IMateriaRepository Materias{get;}
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Materias = new MateriaRepository(_appDbContext);
        }

        public bool Complete()
        {
            return _appDbContext.SaveChanges() > 0;
        }
    }
}