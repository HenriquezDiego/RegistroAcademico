using System;

namespace RegistroAcademico.WebApi.Models
{
    public class Asistencia
    {
        public int AsistenciaId { get; set; }
        public int MatriculaId { get; set; }
        public Matricula Matricula { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}