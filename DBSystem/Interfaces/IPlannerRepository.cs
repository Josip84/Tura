using DBEntities.Entities.Planner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Interfaces
{
    public interface IPlannerRepository
    {
        Task<Planner> CreatePlanner(Planner planner);
        Task<Planner> UpdatePlanner(Planner planner);
        Task<Planner> DeletePlanner(Guid uid);
        Task<IEnumerable<Planner>> GetAllPlanner();
        Task<IEnumerable<Planner>> GetPlannersByDate(DateTime startDate, DateTime endDate);
        Task<Planner> GetPlannerByUID(Guid uid);

    }
}
