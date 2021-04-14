using Microsoft.AspNetCore.Mvc;
using RegistroAcademico.WebApi.DataAccess.Repositories;

namespace RegistroAcademico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _repository;

        public MateriaController(IMateriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll(){
           var values = _repository.GetAll();
           if(values == null) return BadRequest();
           return Ok(values);
        }
    }
}