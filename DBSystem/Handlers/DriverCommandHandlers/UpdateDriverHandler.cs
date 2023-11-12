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
    public class UpdateDriverHandler
    {
        private readonly IDriverRepository driversRepository;

        public UpdateDriverHandler(IDriverRepository driversRepository)
        {
            this.driversRepository = driversRepository;
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

            await driversRepository.UpdateDriverAsync(command.Driver);
        }
    }
}
