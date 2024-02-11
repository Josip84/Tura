using DBEntities.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleQueryHandlers
{
    public class VehicleQueries
    {
    }

    public class GetVehicleByID : IQueryVehicle<Vehicle>
    {
        public int IDVehicle { get; set; }
    }

    public class GetVehicleByPlateNumber: IQueryVehicle<Vehicle>
    {
        public string PlateNumber { get; set;}
    }

    public class GetAllVehicles : IQueryVehicle<IEnumerable<Vehicle>>
    {

    }
}
