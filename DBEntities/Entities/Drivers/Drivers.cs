using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities.Entities.Drivers
{
    public class Drivers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int DriverID { get; set; }
        [Key]
        [System.ComponentModel.DataAnnotations.Required]
        public required string DriverCompanyID { get; set; }        
        public required string DriverLastName { get; set; }
        public required string DriverFirstName { get; set; }
        public string? OIB { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive {  get; set; }
    }
}
