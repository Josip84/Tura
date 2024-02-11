using DBEntities.Entities.Vehicles;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleCommands
{
    public class VehicleCommandHandler :
        IVehicleCommandHandler<CreateVehicleCommand>,
        IVehicleCommandHandler<UpdateVehicleCommand>,
        IVehicleCommandHandler<DeleteVehicleCommand>
    {
        private readonly IVehiclesRepository vehiclesRepository;

        public VehicleCommandHandler(IVehiclesRepository vehiclesRepository)
        {
            this.vehiclesRepository = vehiclesRepository;
        }

        public async Task<Vehicle> Handle(CreateVehicleCommand command)
        {
            return await vehiclesRepository.CreateVehicle(command.Vehicle);
        }

        public async Task<Vehicle> Handle(UpdateVehicleCommand command)
        {
            return await vehiclesRepository.UpdateVehicle(command.Vehicle);
        }

        public async Task<Vehicle> Handle(DeleteVehicleCommand command)
        {
            return await vehiclesRepository.DeleteVehicle(command.IDVehicle);
        }
    }
}
