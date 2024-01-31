using DBEntities.Entities.Planner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerQueryHandlers
{
    public class PlannerQueries
    {
    }

    public class GetAllPlannerQuery : IQueryPlanner<IEnumerable<Planner>>
    {

    }

    public class GetPlannerByUIDQuery : IQueryPlanner<Planner>
    {
        public Guid UIDPlanner { get; set; }
    }

    public class GetPlannerByDateQuery : IQueryPlanner<IEnumerable<Planner>>
    {
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
    }
}
