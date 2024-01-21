using DBEntities.Entities.Drivers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverQueryHandlers
{
    public class DriversQueries
    {
    }

    public class GetDriverByPropertiesQuery : IQueryDrivers<List<Drivers>>
    {
        //public Properties Properties { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }

    public class GetDriverByIdQuery : IQueryDrivers<Drivers>
    {
        public int DriverId { get; set; }
    }

    public class GetDriverByCompanyIdQuery : IQueryDrivers<Drivers>
    {
        public string DriverCompanyId { get; set; }
    }

    public class GetAllDriversQuery : IQueryDrivers<List<Drivers>>
    {
    }
}
