using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverComands;
using DBSystem.Interfaces;

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

        public async Task<Drivers> Handle(GetDriverByIdQuery id)
        {
            var driver = await driverRepository.GetDriverByIdAsync(id.DriverId);

            return driver;
        }

        public async Task<Drivers> Handle(GetDriverByCompanyIdQuery id)
        {
            var driver = await driverRepository.GetDriverByCompanyIdAsync(id.DriverCompanyId);

            return driver;
        }

        public async Task<List<Drivers>> Handle()
        {
            var getalldrivers = await driverRepository.GetAllDriversAsync();

            return getalldrivers.ToList();
        }
    }
}
