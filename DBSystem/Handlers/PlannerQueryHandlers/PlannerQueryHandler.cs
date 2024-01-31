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
    public class PlannerQueryHandler : 
        IQueryHandlerPlanner<GetAllPlannerQuery, IEnumerable<Planner>>,
        IQueryHandlerPlanner<GetPlannerByUIDQuery, Planner>,
        IQueryHandlerPlanner<GetPlannerByDateQuery, IEnumerable<Planner>>
    {
        private readonly IPlannerRepository plannerRepository;

        public PlannerQueryHandler(IPlannerRepository plannerRepository)
        {
            this.plannerRepository = plannerRepository;
        }

        public async Task<IEnumerable<Planner>> Handle(GetAllPlannerQuery query)
        {
            return (await plannerRepository.GetAllPlanner()).ToList();
        }

        public async Task<Planner> Handle(GetPlannerByUIDQuery query)
        {
            return await plannerRepository.GetPlannerByUID(query.UIDPlanner);
        }

        public async Task<IEnumerable<Planner>> Handle(GetPlannerByDateQuery query)
        {
            //return null;
            return (await plannerRepository.GetPlannersByDate(query.StartDate, query.EndDate)).ToList();
        }
    }
}
