using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroAcademico.WebApi.DataAccess;
using RegistroAcademico.WebApi.Inputs;
using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.Controllers
{
    public class MatriculasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MatriculasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {   
            var matriculas = _unitOfWork.Matriculas.GetAll();
            if(matriculas == null) return BadRequest();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {   
            var matricula = _unitOfWork.Matriculas.Get(id);
            if(matricula == null) return BadRequest();
            return Ok(matricula);
        }

        [HttpPost]
        public IActionResult Post(MatriculaInput model)
        {
            var nuevaMatricula = _mapper.Map<Matricula>(model);
            _unitOfWork.Matriculas.Add(nuevaMatricula);
            if(_unitOfWork.Complete()) return new CreatedAtRouteResult(new {id = nuevaMatricula.MatriculaId},nuevaMatricula);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,MatriculaInput model)
        {
            var matricula = _unitOfWork.Matriculas.Get(id);
            if(matricula == null) return BadRequest();
            _mapper.Map(model,matricula);
            if(_unitOfWork.Complete()) return Ok(matricula);
            return StatusCode((int)HttpStatusCode.NotModified);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matricula = _unitOfWork.Matriculas.Get(id);
            if(matricula == null) return BadRequest();
            _unitOfWork.Matriculas.Remove(matricula);
            if(_unitOfWork.Complete()) return NoContent();
            return StatusCode((int)HttpStatusCode.NotModified);
        }
    }
}