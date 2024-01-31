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
    public class PlannerCommandHandler : 
        IPlannerCommandHandler<CreatePlannerCommand>,
        IPlannerCommandHandler<UpdatePlannerCommand>, 
        IPlannerCommandHandler<DeletePlannerCommand>
    {
        public readonly IPlannerRepository? plannerRepository;
        
        public PlannerCommandHandler(IPlannerRepository plannerRepository) 
        {
            this.plannerRepository = plannerRepository;
        }

        public async Task<Planner> Handle(CreatePlannerCommand command)
        {
            return await plannerRepository.CreatePlanner(command.Planner);
        }

        public async Task<Planner> Handle(UpdatePlannerCommand command)
        {
            return await plannerRepository.UpdatePlanner(command.Planner);
        }

        public async Task<Planner> Handle(DeletePlannerCommand command)
        {
            return await plannerRepository.DeletePlanner(command.UIDPlanner);
        }
    }
}
