using DBEntities.Entities.Drivers;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly TuraContext dbContext;

        public DriverRepository(TuraContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Drivers> CreateDriverAsync(Drivers driver)
        {
            dbContext.Drivers.Add(driver);

            // Save changes asynchronously  
            await dbContext.SaveChangesAsync();

            // Return the created driver (with the generated ID)  
            return driver;
        }

        public Task DeleteDriverAsync(int driverId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Drivers>> GetAllDriversAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Drivers> GetDriverByIdAsync(int driverId)
        {
            var driver = await dbContext.Drivers.FindAsync(driverId);

            // Return the driver, or null if not found  
            return driver;
        }

        public async Task<Drivers> UpdateDriverAsync(Drivers driver)
        {
            dbContext.Drivers.Update(driver);

            // Save changes asynchronously  
            await dbContext.SaveChangesAsync();

            // Return the created driver (with the generated ID)  
            return driver;
        }
    }
}
