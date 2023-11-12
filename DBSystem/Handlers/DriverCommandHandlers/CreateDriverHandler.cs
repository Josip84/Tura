using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverCommands;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverCommandHandlers
{
    public class CreateDriverHandler
    {
        private readonly IDriverRepository driverRepository;
        public CreateDriverHandler(IDriverRepository driverRepository) {
            this.driverRepository = driverRepository;
        }

        public async Task<Drivers> Handle(CreateDriverCommand command, TuraContext dbContext)
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

    }
}
