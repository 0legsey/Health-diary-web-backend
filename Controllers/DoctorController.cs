using Backend.Data;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public DoctorController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var doctors = _applicationDBContext.Doctors.ToList().Select(s => s.ToDoctorDto());

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var stock = _applicationDBContext.Doctors.Find(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(stock.ToDoctorDto());
        }
    }
}
