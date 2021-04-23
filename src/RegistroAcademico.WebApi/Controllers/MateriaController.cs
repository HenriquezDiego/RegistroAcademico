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
    public class MateriasController : ControllerBase
    {
        public IMapper _mapper { get; }
        private readonly IUnitOfWork _unitOfWork;

        public MateriasController(IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pedro = _unitOfWork.Materias.GetAll();
            if (pedro == null) return BadRequest();
            return Ok(pedro);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _unitOfWork.Materias.Get(id);
            if (value == null) return BadRequest();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Post(MateriaInput model)
        {
            var materia = _mapper.Map<Materia>(model);
            _unitOfWork.Materias.Add(materia);
            if(_unitOfWork.Complete()) return Ok(materia);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,MateriaInput model)
        {
            var materia = _unitOfWork.Materias.Get(id);
            _mapper.Map(model,materia);
            if(_unitOfWork.Complete()) return Ok(materia);
            return StatusCode((int)HttpStatusCode.NotModified);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var materia = _unitOfWork.Materias.Get(id);
            _unitOfWork.Materias.Remove(materia);
            if(_unitOfWork.Complete())return NoContent();
            return StatusCode((int)HttpStatusCode.NotModified);
        }
    }
}