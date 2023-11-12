using DBEntities.Entities.Users;
using DBEntities.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities.Entities.Planner
{
    public class Planner
    {
        
        [Key]
        public Guid UID { get; set; }
        public DateTime Start { get; set; }
        public string CustomerName { get; set; }
        public int LPostNumber { get; set; }
        public int LPostalNumber { get; set; }
        public string LCityTown { get; set; }
        public string LCountry { get; set; }
        public int UPostalNumber { get; set; }
        public string UCityTown { get; set; }
        public string UCountry { get; set; }
        public Vehicle Vehicle { get; set; }       
        public string UvozIzvoz { get; set; }
        public double TransportPrice { get; set; }
        public string Domaci { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
