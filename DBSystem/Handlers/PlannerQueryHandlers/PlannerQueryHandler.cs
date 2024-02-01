using DBEntities.Entities.Planner;
using DBSystem.Interfaces;

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
            return (await plannerRepository.GetPlannerByDate(query.StartDate, query.EndDate)).ToList();
        }
    }
}
