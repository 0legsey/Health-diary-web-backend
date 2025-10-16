using Backend.Models;

namespace Backend.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient?> GetByIdAsync(int id);
    }
}
