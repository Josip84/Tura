using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Commands.TourCommands
{
    public class GetTourByDateQuery
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
