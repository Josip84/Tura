using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities.Entities.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required] 
        public required string LastName { get; set; }
        [Required] 
        public required string UserName { get; set; }
        [Required] 
        public required string Password { get; set; }
    }
}
