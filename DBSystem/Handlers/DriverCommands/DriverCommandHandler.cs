using DBEntities.Entities.Drivers;
using DBSystem.Interfaces;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverCommands
{
    public class DriverCommandHandler :
        ICommandDriversHandler<CreateDriverCommand>,
        ICommandDriversHandler<UpdateDriverCommand>,
        ICommandDriversHandler<DeleteDriverCommand>
    {
        private readonly IDriverRepository driverRepository;

        public DriverCommandHandler(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }
        public async Task<Drivers> Handle(UpdateDriverCommand command)
        {
            return await driverRepository.UpdateDriverAsync(command.Driver);
        }

        public async Task<Drivers> Handle(CreateDriverCommand command)
        {
            return await driverRepository.CreateDriverAsync(command.Driver);
        }

        public async Task<Drivers> Handle(DeleteDriverCommand command)
        {
            return await driverRepository.DeleteDriverAsync(command.DriverID);
        }
    }
}
