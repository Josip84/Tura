using DBEntities.Entities.Drivers;
using DBEntities.Entities.Vehicles;
using DBSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Repositories
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private TuraContext dbContext;

        public VehiclesRepository(TuraContext turaContext)
        {
            this.dbContext = turaContext;
        }
        public async Task<Vehicle?> CreateVehicle(Vehicle vehicle)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Vehicles.Add(vehicle);

                        await dbContext.SaveChangesAsync();

                        transaction.Commit();
 
                        return vehicle;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine($"Error: {ex.Message}");

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                return null;
            }
        }

        public async Task<Vehicle?> DeleteVehicle(int IDVehicle)
        {
            var vehicle = await dbContext.Vehicles.FirstOrDefaultAsync(d => d.VehicleID == IDVehicle);
            if (vehicle != null)
            {
                dbContext.Vehicles.Remove(vehicle);
                await dbContext.SaveChangesAsync();
                return vehicle;
            }

            return null;
        }

        public async Task<Vehicle?> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Vehicles.Update(vehicle);

                        await dbContext.SaveChangesAsync();

                        transaction.Commit();

                        return vehicle;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine($"Concurrency error: {ex.Message}");

                        throw new Exception("Concurrency error occurred while updating the driver.", ex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw new Exception("Concurrency error occurred while updating the driver.", ex);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                throw new Exception("Concurrency error occurred while updating the driver.", ex);
            }
        }

        public async Task<IEnumerable<Vehicle?>> GetAllVehicles()
        {
            return await dbContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByID(int IDVehicle)
        {
            var vehicle = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.VehicleID == IDVehicle);
            
            return vehicle;
        }

        public async Task<Vehicle> GetVehicleByPlateNumber(string PlateNumber)
        {
            var vehicle = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.PlateNumber == PlateNumber);
            return vehicle;
        }

    }
}
