using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.Models
{
    public class Databases:DbContext
    {
        public Databases(DbContextOptions<Databases> data):base(data)
        {

        }
        public DbSet<Home> homes { get; set; }
       
      
    }
}
