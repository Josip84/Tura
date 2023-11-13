using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverCommands;
using DBSystem.Interfaces;
using DBSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverCommandHandlers
{
    public class DriverCommandHandler
    {
        private readonly IDriverRepository driverRepository;
        public DriverCommandHandler(IDriverRepository driverRepository) {
            this.driverRepository = driverRepository;
        }

        public async Task<Drivers> Handle(CreateDriverCommand command)
        {
            // Convert the DriversDto to a Drivers entity    
            /*var driver = new Drivers
            {
                DriverCompanyID = command.Driver.DriverCompanyID,
                DriverLastName = command.Driver.DriverLastName,
                DriverFirstName = command.Driver.DriverFirstName
            };*/

            //return await driverRepository.CreateDriverAsync(driver);

            return await driverRepository.CreateDriverAsync(command.Driver);
        }

        public async Task<Drivers> Handle(DeleteDriverCommand command)
        {
            return await driverRepository.DeleteDriverAsync(command.DriverId);
        }

        public async Task Handle(UpdateDriverCommand command)
        {
            /*var driver = new Drivers
            {
                DriverID = command.Driver.DriverID,
                DriverCompanyID = command.Driver.DriverCompanyID,
                DriverLastName = command.Driver.DriverLastName,
                DriverFirstName = command.Driver.DriverFirstName,
                // ... (other properties)  
            };

            await driversRepository.UpdateDriverAsync(driver);  */

            await driverRepository.UpdateDriverAsync(command.Driver);
        }

    }
}
