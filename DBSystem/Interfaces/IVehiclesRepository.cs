using DBEntities.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Interfaces
{
    public interface IVehiclesRepository
    {
        Task<Vehicle?> CreateVehicle(Vehicle vehicle);
        Task<Vehicle?> UpdateVehicle(Vehicle vehicle);
        Task<Vehicle?> DeleteVehicle(int IDVehicle);
        Task<IEnumerable<Vehicle?>> GetAllVehicles();
        Task<Vehicle> GetVehicleByID(int IDVehicle);
        Task<Vehicle> GetVehicleByPlateNumber(string PlateNumber);
    }
}
