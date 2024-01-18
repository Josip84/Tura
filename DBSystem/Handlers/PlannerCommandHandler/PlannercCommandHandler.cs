using DBEntities.Entities.Planner;
using DBSystem.Commands.PlannerCommands;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerCommandHandler
{
    public class PlannercCommandHandler
    {
        public readonly IPlannerRepository? plannerRepository;
        
        public PlannercCommandHandler(IPlannerRepository plannerRepository) 
        {
            this.plannerRepository = plannerRepository;
        }

        public async Task<Planner> Handle(CreatePlannerCommand command) => await plannerRepository.CreatePlanner(command.Planner);
        public async Task<Planner> Handle(UpdatePlannerCommand command) => await plannerRepository.UpdatePlanner(command.Planner);
        public async Task Handle(Guid plannerID)
        {
            await plannerRepository.DeletePlanner(plannerID);
        }
    }
}
