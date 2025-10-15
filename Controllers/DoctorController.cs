using Backend.Data;
using Backend.Dtos.Doctor;
using Backend.Mappers;
using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var doctor = _applicationDBContext.Doctors.Find(id);

            if (doctor == null) {
                return NotFound();
            }

            return Ok(doctor.ToDoctorDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDoctorRequestDto doctorDto)
        {
            var doctorModel = doctorDto.ToDoctorFromDoctorDto();
            _applicationDBContext.Add(doctorModel);
            _applicationDBContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = doctorModel.Id }, doctorModel.ToDoctorDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateDoctorRequestDto updateDto)
        {
            var doctorModel = _applicationDBContext.Doctors.FirstOrDefault(x => x.Id == id);

            if (doctorModel == null) {
                return NotFound();
            }

            doctorModel.LicenceNumber = updateDto.LicenceNumber;
            doctorModel.Email = updateDto.Email;
            doctorModel.FirstName = updateDto.FirstName;
            doctorModel.LastName = updateDto.LastName;
            doctorModel.PhoneNumber = updateDto.PhoneNumber;
            doctorModel.BirthDate = updateDto.BirthDate;
            doctorModel.CreatedAt = updateDto.CreatedAt;
            doctorModel.Specialization = updateDto.Specialization;
            doctorModel.Experience = updateDto.Experience;
            doctorModel.Patients = updateDto.Patients;

            _applicationDBContext.SaveChanges();
            return Ok(doctorModel.ToDoctorDto());
        }
    }
}
