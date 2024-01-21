using DBEntities.Entities.Drivers;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.Commands
{
    public class DriverCommands
    {

    }

    /*public class NewCreateDriverCommand : ICommand
    {
        public Drivers Driver { get; set; }
    }

    public class NewDeleteDriverCommand : ICommand
    {
        public int DriverId { get; set; }
    }

    public class NewUpdateDriverCommand : ICommand
    {
        public Drivers Driver { get; set; }
    }*/

    public class CreateDriverCommand : ICommandDrivers
    {
        public Drivers Driver { get; set; }
        public async Task<Drivers> Execute(IDriverRepository driverRepository)
        {
            return await driverRepository.CreateDriverAsync(Driver);
        }
    }

    public class UpdateDriverCommand : ICommandDrivers
    {
        public Drivers Driver { get; set;}

        public async Task<Drivers> Execute(IDriverRepository driverRepository)
        {
            return await driverRepository.UpdateDriverAsync(Driver);
        }
    }

    public class DeleteDriverCommand : ICommandDrivers
    {
        public int DriverID { get; set;}

        public async Task<Drivers> Execute(IDriverRepository driverRepository)
        {
            return await driverRepository.DeleteDriverAsync(DriverID);
        }
    }
}
