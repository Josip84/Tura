using DBEntities.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Commands.DriverComands
{
    public class GetDriverByPropertiesQuery
    {
        public Dictionary<string, object> Properties { get; set; }
    }
}
