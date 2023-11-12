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
    public class DeleteDriverHandler
    {
        private readonly IDriverRepository driversRepository;

        public DeleteDriverHandler(IDriverRepository driversRepository)
        {
            this.driversRepository = driversRepository;
        }

        public async Task Handle(DeleteDriverCommand command)
        {
            await driversRepository.DeleteDriverAsync(command.Driver.DriverID);
        }
    }
}
