using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.Models
{
    public class Home
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string photopath { get; set; }

    }
}
