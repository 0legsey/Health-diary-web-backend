using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Patient
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ChronicDeseases { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;
        public int? DoctorId { get; set; }
    }
}
