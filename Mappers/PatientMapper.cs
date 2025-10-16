using Backend.Dtos.Doctor;
using Backend.Dtos.Patient;
using Backend.Models;

namespace Backend.Mappers
{
    public static class PatientMapper
    {
        public static PatientDto toPatientDto(this Patient patientModel)
        {
            return new PatientDto
            {
                Id = patientModel.Id,
                Email = patientModel.Email,
                FirstName = patientModel.FirstName,
                LastName = patientModel.LastName,
                PhoneNumber = patientModel.PhoneNumber,
                BirthDate = patientModel.BirthDate,
                CreatedAt = patientModel.CreatedAt,
                ChronicDeseases = patientModel.ChronicDeseases,
                Allergies = patientModel.Allergies,
                DoctorId = patientModel.DoctorId
            };

        }
    }
}
