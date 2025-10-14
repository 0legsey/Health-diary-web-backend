using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Patient
    {
        public int Id { get; set; }
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
        public DateTime CreatedAt { get; set; }
        [MaxLength(255)]
        public string ChronicDeseases { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Allergies { get; set; } = string.Empty;
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; } //Navigation property
    }
}
