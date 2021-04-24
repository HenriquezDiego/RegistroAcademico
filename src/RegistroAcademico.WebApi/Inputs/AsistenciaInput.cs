using System;

namespace RegistroAcademico.WebApi.Inputs
{
    public class AsistenciaInput
    {
        public int MatriculaId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}