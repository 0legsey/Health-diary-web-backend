using Backend.Dtos.Patient;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        public PatientController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patientModel = await _patientService.GetAllAsync();
            var patientDto = patientModel.Select(s => s.toPatientDto());

            return Ok(patientDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.toPatientDto());
        }

        [HttpPost("{doctorId}")]
        public async Task<IActionResult> Create([FromRoute] int doctorId, [FromBody] CreatePatientRequestDto patientDto)
        {
            if (!await _doctorService.DoctorExists(doctorId))
            {
                return BadRequest("Doctor does not exist");
            }

            var patientModel = patientDto.ToPatientFromPatientDto(doctorId);

            await _patientService.CreateAsync(patientModel);

            return CreatedAtAction(nameof(GetById), new { id = patientModel.Id }, patientModel.toPatientDto());
        }

    }
}
