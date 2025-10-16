using Backend.Dtos.Doctor;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task<Doctor> CreateAsync(Doctor doctorModel);
        Task<Doctor?> UpdateAsync(int id, UpdateDoctorRequestDto doctorDto);
        Task<Doctor> DeleteAsync(int id);
        Task<bool> DoctorExists(int id);
    }
}
