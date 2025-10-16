using Backend.Models;

namespace Backend.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllAsync();
    }
}
