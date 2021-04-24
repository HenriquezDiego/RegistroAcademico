using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroAcademico.WebApi.DataAccess;
using RegistroAcademico.WebApi.Inputs;
using RegistroAcademico.WebApi.Models;

namespace RegistroAcademico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public AsistenciasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var asistencias = _unitOfWork.Asistencias.GetAll();
            if(asistencias == null) return BadRequest();
            return Ok(asistencias);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var asistencia = _unitOfWork.Asistencias.Get(id);
            if(asistencia == null) return BadRequest();
            return Ok(asistencia);
        }

        [HttpPost]
        public IActionResult Post(AsistenciaInput model)
        {
            var nuevoAsistencia = _mapper.Map<Asistencia>(model);
            _unitOfWork.Asistencias.Add(nuevoAsistencia);
            if(_unitOfWork.Complete()) return new CreatedAtRouteResult(new {id = nuevoAsistencia.AsistenciaId},nuevoAsistencia);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AsistenciaInput model)
        {
            var asistencia = _unitOfWork.Asistencias.Get(id);
            if(asistencia == null) return BadRequest();
            _mapper.Map(model,asistencia);
            if(_unitOfWork.Complete()) return Ok(asistencia);
            return StatusCode((int)HttpStatusCode.NotModified);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var asistencia = _unitOfWork.Asistencias.Get(id);
            if(asistencia == null) return BadRequest();
            _unitOfWork.Asistencias.Remove(asistencia);
            if(_unitOfWork.Complete()) return NoContent();
            return StatusCode((int)HttpStatusCode.NotModified);
        }
    
    }
}