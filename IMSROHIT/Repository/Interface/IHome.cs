using IMSROHIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.Repository.Interface
{
    public interface IHome
    {
        Home GetHome(int id);
        IEnumerable<Home> GetAllHome();
        Home add(Home home);
        Home update(Home home);
        Home Delete(int id);
        List<Home> SearchHome(string search);


    }
}
