﻿using DBEntities.Entities.Drivers;
using DBSystem.Interfaces;

namespace DBSystem.Handlers.DriverQueryHandlers
{
    public class DriverQueryHandler :
        IQueryHandlerDrivers<GetDriverByPropertiesQuery, List<Drivers>>,
        IQueryHandlerDrivers<GetDriverByIdQuery, Drivers>,
        IQueryHandlerDrivers<GetDriverByCompanyIdQuery, Drivers>,
        IQueryHandlerDrivers<GetAllDriversQuery, List<Drivers>>
    {

        private readonly IDriverRepository driverRepository;

        public DriverQueryHandler(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public async Task<List<Drivers>> Handle(GetDriverByPropertiesQuery query)
        {
            return await driverRepository.GetDriversByPropertiesAsync(query.Properties);
        }

        public async Task<Drivers> Handle(GetDriverByIdQuery query)
        {
            return await driverRepository.GetDriverByIdAsync(query.DriverId);
        }

        public async Task<Drivers> Handle(GetDriverByCompanyIdQuery query)
        {
            return await driverRepository.GetDriverByCompanyIdAsync(query.DriverCompanyId);
        }

        public async Task<List<Drivers>> Handle(GetAllDriversQuery query)
        {
            return (await driverRepository.GetAllDriversAsync()).ToList();
        }
    }
}
