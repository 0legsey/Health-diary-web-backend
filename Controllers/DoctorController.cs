using Backend.Data;
using Backend.Dtos.Doctor;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly IDoctorService _doctorService;
        public DoctorController(ApplicationDBContext applicationDBContext, IDoctorService doctorService)
        {
            _applicationDBContext = applicationDBContext;
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorService.GetAllAsync();
            var doctorsDto = doctors.Select(s => s.ToDoctorDto());

            return Ok(doctorsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var doctor = await _applicationDBContext.Doctors.FindAsync(id);

            if (doctor == null) {
                return NotFound();
            }

            return Ok(doctor.ToDoctorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorRequestDto doctorDto)
        {
            var doctorModel = doctorDto.ToDoctorFromDoctorDto();
            await _applicationDBContext.AddAsync(doctorModel);
            await _applicationDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = doctorModel.Id }, doctorModel.ToDoctorDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDoctorRequestDto updateDto)
        {
            var doctorModel = await _applicationDBContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

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

            await _applicationDBContext.SaveChangesAsync();
            return Ok(doctorModel.ToDoctorDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var doctorModel = await _applicationDBContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (doctorModel == null) { 
                return NotFound(); 
            }

            _applicationDBContext.Doctors.Remove(doctorModel);

            await _applicationDBContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
