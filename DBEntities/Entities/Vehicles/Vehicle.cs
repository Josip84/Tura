using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities.Entities.Vehicles
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public required string PlateNumber { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public int VehicleTypeId { get; set; } // Foreign key property


        [Required]
        public virtual VehiclesType VehicleType { get; set; }

    }
}
