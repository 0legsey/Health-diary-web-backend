using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string LicenceNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string PasswordHash { get; set; } = string.Empty;
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Column(TypeName = "timestamp without time zone")]
        public DateTime BirthDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string Specialization { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Experience { get; set; } = string.Empty;
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
