﻿using DBEntities.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverCommands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommandDrivers
    {
        Task<Drivers> Handle(TCommand command);
    }
}
