using DBEntities.Entities.Vehicles;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleCommands
{
    public interface ICommandsVehicle
    {
        Task<Vehicle> Execute(IVehiclesRepository vehiclesRepository);
    }
}
