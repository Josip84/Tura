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

        public Task<Drivers> GetDriverByIdAsync(int driverId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDriverAsync(Drivers driver)
        {
            throw new NotImplementedException();
        }
    }
}
