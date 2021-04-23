using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroAcademico.WebApi.DataAccess;

namespace RegistroAcademico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlumnosController : ControllerBase
    {
        public IMapper _mapper { get; }
        public IUnitOfWork _unitOfWork { get; }
        public AlumnosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return null;
        }
    }
}