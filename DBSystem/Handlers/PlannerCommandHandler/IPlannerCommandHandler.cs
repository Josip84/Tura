using DBEntities.Entities.Planner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerCommandHandler
{
    public interface IPlannerCommandHandler<TCommand> where TCommand : ICommandPlanner
    {
        Task<Planner> Handle(TCommand command);
    }
}
