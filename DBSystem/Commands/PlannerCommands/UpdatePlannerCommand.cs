using DBEntities.Entities.Planner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Commands.PlannerCommands
{
    public class UpdatePlannerCommand
    {
        public Planner? Planner { get; set; }
    }
}
