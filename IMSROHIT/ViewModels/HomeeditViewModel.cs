using IMSROHIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.ViewModels
{
    public class HomeeditViewModel:HomecreateViewModel
    {
        public Home home { get; set; }
        public int Id { get; set; }
        public string Existingphoto { get; set; }
       
    }
}
