using DBEntities.Entities.Planner;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerCommandHandler
{
    public class CommandPlanner
    {
      
    }

    public class CreatePlannerCommand : ICommandPlanner
    {
        public Planner Planner { get; set; }

        public async Task<Planner> Execute(IPlannerRepository plannerRepository)
        {
            return await plannerRepository.CreatePlanner(Planner);
        }
    }

    public class UpdatePlannerCommand : ICommandPlanner
    {
        public Planner Planner { get; set; }

        public async Task<Planner> Execute(IPlannerRepository plannerRepository)
        {
            return await plannerRepository.UpdatePlanner(Planner);
        }
    }

    public class DeletePlannerCommand : ICommandPlanner
    {
        public Guid UIDPlanner { get; set;}

        public async Task<Planner> Execute(IPlannerRepository plannerRepository)
        {
            return await plannerRepository.DeletePlanner(UIDPlanner);
        }
    }
}
