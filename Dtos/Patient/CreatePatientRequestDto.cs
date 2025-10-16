namespace Backend.Dtos.Patient
{
    public class CreatePatientRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string ChronicDeseases { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;
    }
}
