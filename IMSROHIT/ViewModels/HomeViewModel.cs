using IMSROHIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.ViewModels
{
    public class HomeViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Home employees { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}
