using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class PatientService : IPatientService
    {
        ApplicationDBContext _applicationDbContext;
        public PatientService(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _applicationDbContext.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Patients.FindAsync(id);
        }
    }
}
