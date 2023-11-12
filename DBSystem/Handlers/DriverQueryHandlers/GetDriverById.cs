using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverComands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverQueryHandlers
{
    public class GetDriverById
    {
        public async Task<Drivers> Handle(GetDriverByIdQuery query, TuraContext dbContext)
        {
            var driver = await dbContext.Drivers.FindAsync(query.DriverID);

            /*if (driver != null)
            {
                // Convert the Drivers entity to a DriversDto  
                var dto = new DriversDto
                {
                    DriverID = driver.DriverID,
                    DriverCompanyID = driver.DriverCompanyID,
                    DriverLastName = driver.DriverLastName,
                    DriverFirstName = driver.DriverFirstName,
                    // ... (other properties)  
                };

                return dto;
            }*/

            if (driver != null)
            {
                return driver;
            }

            return null;
        }
    }
}
