using DBEntities.Entities.Planner;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerCommandHandler
{
    public interface ICommandPlanner
    {
        Task<Planner> Execute(IPlannerRepository plannerRepository);
    }
}
