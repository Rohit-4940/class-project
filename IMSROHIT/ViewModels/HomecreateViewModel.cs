using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.ViewModels
{
    public class HomecreateViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Name { get; set; }
        [Required]
        public String Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<IFormFile> photos { get; set; }
    }
}
