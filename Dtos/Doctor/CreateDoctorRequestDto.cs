using Backend.Dtos.Patient;
using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Doctor
{
    public class CreateDoctorRequestDto
    {
        public string LicenceNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public List<PatientDto> Patients { get; set; } = new List<PatientDto>();
    }
}
