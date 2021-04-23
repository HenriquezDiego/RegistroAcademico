using RegistroAcademico.WebApi.DataAccess.Repositories;

namespace RegistroAcademico.WebApi.DataAccess
{
    public interface IUnitOfWork
    {
        IMateriaRepository Materias {get;}
        IEstudianteRepository Estudiantes {get;}
        bool Complete();
    }
}