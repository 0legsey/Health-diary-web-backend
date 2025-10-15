using Backend.Data;
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
        Task<List<Doctor>> IDoctorService.GetAllAsync()
        {
            return _applicationDbContext.Doctors.ToListAsync();
        }
    }
}
