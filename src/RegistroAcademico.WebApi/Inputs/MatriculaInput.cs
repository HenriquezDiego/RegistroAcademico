using System;

namespace RegistroAcademico.WebApi.Inputs
{
    public class MatriculaInput
    {
         public int MatriculaId { get; set; }
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
        public DateTime Fecha { get; set; }
    }
}