using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllAsync();
    }
}
