using DBEntities.Entities.Planner;
using DBSystem.Commands.PlannerCommands;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerQueryHandlers
{
    public class PlannerQueryHandler
    {
        private readonly IPlannerRepository plannerRepository;

        public PlannerQueryHandler(IPlannerRepository plannerRepository)
        {
            this.plannerRepository = plannerRepository;
        }

        public async Task<IEnumerable<Planner>> Handle(GetPlannerFromDate query)
        {
            return await plannerRepository.GetPlannersByDate(query.StartDate, query.EndDate);
        }

        public async Task<Planner> Handle(GetPlannerByUID planner)
        {
            return await plannerRepository.GetPlannerByUID(planner.PlannerUID);
        }

        public async Task<IEnumerable<Planner>> Handle()
        {
            return await plannerRepository.GetAllPlanner();
        }
    }
}
