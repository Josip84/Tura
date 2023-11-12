using DBEntities.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Services.DriverCommandService
{
    public class DriverQueryService
    {
        private readonly TuraContext dbContext;

        public DriverQueryService(TuraContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Drivers> GetAllDrivers()
        {
            return dbContext.Drivers;
        }

        public Drivers? GetDriverById(int DriverId)
        {
            return dbContext.Drivers.FirstOrDefault(d => d.DriverID == DriverId);
        }
    }
}
