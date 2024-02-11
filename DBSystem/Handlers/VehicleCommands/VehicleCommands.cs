using DBEntities.Entities.Vehicles;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleCommands
{
    public class VehicleCommands
    {

    }

    public class CreateVehicleCommand : ICommandsVehicle
    {
        public required Vehicle Vehicle { get; set; }
        
        public async Task<Vehicle> Execute(IVehiclesRepository vehiclesRepository)
        {
            return await vehiclesRepository.CreateVehicle(Vehicle);
        }
    }

    public class DeleteVehicleCommand : ICommandsVehicle
    {
        public required int IDVehicle { get; set; }

        public async Task<Vehicle> Execute(IVehiclesRepository vehiclesRepository)
        {
            return await vehiclesRepository.DeleteVehicle(IDVehicle);
        }
    }

    public class UpdateVehicleCommand : ICommandsVehicle
    {
        public required Vehicle Vehicle { get; set; }

        public async Task<Vehicle> Execute(IVehiclesRepository vehiclesRepository)
        {
            return await vehiclesRepository.UpdateVehicle(Vehicle);
        }
    }
}
