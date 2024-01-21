using DBEntities.Entities.Drivers;
using DBEntities.Entities.Users;
using DBSystem.Interfaces;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DBSystem.Handlers
{
    // The ICommand interface is empty because it’s being used as a marker interface.
    // A marker interface is an interface with no fields or methods.It is used to mark a class as having a certain property or behavior.In this case, ICommand is used to mark certain classes as commands.
    //This can be useful in a system where you have many different types of commands, and you want to be able to handle them in a generic way.For example, you might have a method that takes an ICommand parameter, and then performs some action based on the specific type of command.

    public interface ICommandDrivers
    {
        Task<Drivers> Execute(IDriverRepository driverRepository);
    }
}
