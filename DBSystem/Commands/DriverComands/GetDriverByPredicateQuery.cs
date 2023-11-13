using DBEntities.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Commands.DriverComands
{
    public class GetDriverByPredicateQuery
    {
        public Expression<Func<Drivers, bool>> Predicate { get; set; }
    }
}
