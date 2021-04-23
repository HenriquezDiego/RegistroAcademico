using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroAcademico.WebApi.DataAccess;
using RegistroAcademico.WebApi.Inputs;
using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EstudiantesController : ControllerBase
    {
        public IMapper _mapper { get; }
        public IUnitOfWork _unitOfWork { get; }
        public EstudiantesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var estudiantes = _unitOfWork.Estudiantes.GetAll();
            if(estudiantes == null) return BadRequest();
            return Ok(estudiantes);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estudiante = _unitOfWork.Estudiantes.Get(id);
            if(estudiante == null) return BadRequest();
            return Ok(estudiante);
        }

        [HttpPost]
        public IActionResult Post(EstudianteInput model)
        {
            var nuevoEstudiante = _mapper.Map<Estudiante>(model);
            _unitOfWork.Estudiantes.Add(nuevoEstudiante);
            if(_unitOfWork.Complete()) return new CreatedAtRouteResult(new {id = nuevoEstudiante.EstudianteId},nuevoEstudiante);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EstudianteInput model)
        {
            var estudiante = _unitOfWork.Estudiantes.Get(id);
            if(estudiante == null) return BadRequest();
            _mapper.Map(model,estudiante);
            if(_unitOfWork.Complete()) return Ok(estudiante);
            return StatusCode((int)HttpStatusCode.NotModified);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var estudiante = _unitOfWork.Estudiantes.Get(id);
            if(estudiante == null) return BadRequest();
            _unitOfWork.Estudiantes.Remove(estudiante);
            if(_unitOfWork.Complete()) return Ok(estudiante);
            return StatusCode((int)HttpStatusCode.NotModified);
        }
    }
}