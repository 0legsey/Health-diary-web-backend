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
        public static Patient ToPatientFromPatientDto(this CreatePatientRequestDto patientDto, int doctorId)
        {
            return new Patient
            {
                Email = patientDto.Email,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                PasswordHash = patientDto.PasswordHash,
                PhoneNumber = patientDto.PhoneNumber,
                BirthDate = patientDto.BirthDate,
                ChronicDeseases = patientDto.ChronicDeseases,
                Allergies = patientDto.Allergies,
                DoctorId = doctorId
            };
        }

    }
}
