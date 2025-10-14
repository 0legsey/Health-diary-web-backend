using Backend.Dtos.Doctor;
using Backend.Models;

namespace Backend.Mappers
{
    public static class DoctorMappers
    {
        public static DoctorDto ToDoctorDto(this Doctor doctorModel)
        {
            return new DoctorDto
            {
                Id = doctorModel.Id,
                LicenceNumber = doctorModel.LicenceNumber,
                Email = doctorModel.Email,
                FirstName = doctorModel.FirstName,
                LastName = doctorModel.LastName,
                PhoneNumber = doctorModel.PhoneNumber,
                BirthDate = doctorModel.BirthDate,
                CreatedAt = doctorModel.CreatedAt,
                Specialization = doctorModel.Specialization,
                Experience = doctorModel.Experience,
                Patients = doctorModel.Patients
            };
        }
    }
}
