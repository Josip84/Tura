using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverComands;
using DBSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverQueryHandlers
{
    public class DriverQueryHandler
    {
        private readonly IDriverRepository driverRepository;
        public DriverQueryHandler(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public async Task<List<Drivers>> Handle(GetDriverByPropertiesQuery query)
        {
            var drivers = await driverRepository.GetDriversByPropertiesAsync(query.Properties);

            return drivers;
        }
    }
}
