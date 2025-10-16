using Backend.Data;
using Backend.Dtos.Doctor;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDBContext _applicationDbContext;
        public DoctorService(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Doctor> CreateAsync(Doctor doctorModel)
        {
            await _applicationDbContext.AddAsync(doctorModel);
            await _applicationDbContext.SaveChangesAsync();
            return doctorModel;
        }

        public async Task<Doctor> DeleteAsync(int id)
        {
            var doctorModel = await _applicationDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (doctorModel == null)
            {
                return null;
            }

            _applicationDbContext.Doctors.Remove(doctorModel);

            await _applicationDbContext.SaveChangesAsync();

            return doctorModel;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _applicationDbContext.Doctors.Include(d => d.Patients).ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Doctors.Include(d => d.Patients).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor?> UpdateAsync(int id, UpdateDoctorRequestDto doctorDto)
        {
            var doctorModel = await _applicationDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (doctorModel == null)
            {
                return null;
            }

            doctorModel.LicenceNumber = doctorDto.LicenceNumber;
            doctorModel.Email = doctorDto.Email;
            doctorModel.FirstName = doctorDto.FirstName;
            doctorModel.LastName = doctorDto.LastName;
            doctorModel.PasswordHash = doctorDto.PasswordHash;
            doctorModel.PhoneNumber = doctorDto.PhoneNumber;
            doctorModel.BirthDate = doctorDto.BirthDate;
            doctorModel.CreatedAt = doctorDto.CreatedAt;
            doctorModel.Specialization = doctorDto.Specialization;
            doctorModel.Experience = doctorDto.Experience;
            //doctorModel.Patients = doctorDto.Patients;

            await _applicationDbContext.SaveChangesAsync();

            return doctorModel;
        }
    }
}
