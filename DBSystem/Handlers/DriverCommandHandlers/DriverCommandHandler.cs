using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverComands;
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
            return await driverRepository.CreateDriverAsync(command.Driver);
        }

        public async Task<Drivers> Handle(DeleteDriverCommand command)
        {
            return await driverRepository.DeleteDriverAsync(command.DriverId);
        }

        public async Task Handle(UpdateDriverCommand command)
        {
            await driverRepository.UpdateDriverAsync(command.Driver);
        }
    }
}
