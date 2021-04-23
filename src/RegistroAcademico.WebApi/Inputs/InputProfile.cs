using AutoMapper;
using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.Inputs
{
    public class InputProfile : Profile
    {
        public InputProfile()
        {
            CreateMap<MateriaInput,Materia>();
            CreateMap<EstudianteInput,Estudiante>();
        }
    }
}