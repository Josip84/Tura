using DBEntities.Entities.Vehicles;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleQueryHandlers
{
    public class VehicleQueryHandler :
        IQueryHandlerVehicle<GetAllVehicles, IEnumerable<Vehicle>>,
        IQueryHandlerVehicle<GetVehicleByID, Vehicle>,
        IQueryHandlerVehicle<GetVehicleByPlateNumber, Vehicle>
    {
        private readonly IVehiclesRepository vehiclesRepository;

        public VehicleQueryHandler(IVehiclesRepository vehiclesRepository)
        {
            this.vehiclesRepository = vehiclesRepository;
        }

        public async Task<IEnumerable<Vehicle>> Handle(GetAllVehicles query)
        {
            return (await vehiclesRepository.GetAllVehicles()).ToList();
        }

        public async Task<Vehicle> Handle(GetVehicleByID query)
        {
            return await vehiclesRepository.GetVehicleByID(query.IDVehicle);
        }

        public async Task<Vehicle> Handle(GetVehicleByPlateNumber query)
        {
            return await vehiclesRepository.GetVehicleByPlateNumber(query.PlateNumber);
        }
    }
}
