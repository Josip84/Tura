using DBEntities.Entities.Drivers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Services.DriverQueryService
{
    public class DriversCommandService
    {
        private readonly TuraContext dbContext;

        public DriversCommandService(TuraContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddDriver(Drivers driver)
        {
            dbContext.Drivers.Add(driver);
            dbContext.SaveChanges();
        }

        private void UpdateDriver(Drivers driver)
        {
            dbContext.Drivers.Update(driver);
            dbContext.SaveChanges();
        }

        private void DeleteDriver(int driverId)
        {
            var driverToDelete = dbContext.Drivers.Find(driverId);
            if (driverToDelete != null)
            {
                dbContext.Drivers.Remove(driverToDelete);
                dbContext.SaveChanges();
            }
        }

        public void UpdateDriverIsActive(int driverId, bool isActive)
        {
            var driverToUpdate = dbContext.Drivers.Find(driverId);

            if (driverToUpdate != null)
            {
                driverToUpdate.IsActive = isActive;
                dbContext.SaveChanges();
            }
        }
    }
}
