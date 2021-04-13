using System;

namespace RegistroAcademico.WebApi.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public DateTime Fecha { get; set; }
    }
}