using DBEntities.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleCommands
{
    public interface IVehicleCommandHandler<TCommand> where TCommand : ICommandsVehicle
    {
        Task<Vehicle> Handle(TCommand command);
    }
}
