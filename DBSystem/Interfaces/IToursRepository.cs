using DBEntities.Entities.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Interfaces
{
    public interface IToursRepository
    {
        Task<Tours?> CreateTour(Tours tour);
        Task<Tours?> UpdateTour(Tours tour);
        Task<Tours?> DeleteTour(string tourID);
        Task<List<Tours>> GetAllTours();
        Task<Tours?> GetTour(String tourID);
        Task<List<Tours>> GetToursByDate(DateTime startDate, DateTime endDate);
    }
}
