﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Commands.TourCommands
{
    public class GetTourByIDQuery
    {
        public required string TourID { get; set; }
    }
}