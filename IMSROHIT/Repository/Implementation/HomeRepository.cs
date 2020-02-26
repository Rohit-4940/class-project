
using IMSROHIT.Models;
using IMSROHIT.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.Repository.Implementation
{
    public class HomeRepository:IHome
    {
        private List<Home> _HomeList;
        public HomeRepository()
        {
            _HomeList = new List<Home>()
            {
                new Home(){id=1,Name="Dipendra thapa",Email="thapa@gmail.com",Department="IT"},
                new Home(){id=2,Name="Pawan Kumar shrestha",Email="Pawan@gamil.com",Department="Manager"},
                new Home(){id=3,Name="ram lama",Email="ram123@gmail.com",Department="Network"},
                 new Home(){id=4,Name="shyam lama",Email="lamashyam@gmail.com",Department="Network"},
                 new Home(){id=5,Name="hari lama",Email="hari6474@gmail.com",Department="Network"},
                 new Home(){id=6,Name="saroj shrestha",Email="gopali7892@gmail.com",Department="Network"},
                 new Home(){id=7,Name="saroj gopali",Email="saroj12343hh@gmail.com",Department="Network"},
                 new Home(){id=8,Name="sanish shrestha",Email="shresthasanaish123@gmail.com",Department="Network"},
                 new Home(){id=9,Name="ujjwal lama",Email="lamaujjwal123@gmail.com",Department="Network"},
                 new Home(){id=10,Name="amit lama",Email="lama123@gmail.com",Department="Network"},
                 new Home(){id=11,Name="sunny khadka",Email="lhadkasunny@gmail.com",Department="Network"},
                 new Home(){id=12,Name="Rubin magar",Email="mgrrubin2029@gmail.com",Department="Network"},
                 new Home(){id=13,Name="nanda magar",Email="mgrnamda5678@gmail.com",Department="Network"},
            };
        }

        public Home add(Home home)
        {
            home.id = _HomeList.Max(e => e.id) + 1;
            _HomeList.Add(home);
            return home;
        }
        
        public Home Delete(int id)
        {
            Home home = _HomeList.FirstOrDefault(e => e.id == id);
            if (home != null)
            {
                _HomeList.Remove(home);
            }
            return home;
        }

        public IEnumerable<Home> GetAllHome()
        {
            return _HomeList;
        }

        public Home GetHome(int id)
        {
            return _HomeList.FirstOrDefault(e => e.id == id);
        }

        public List<Home> SearchHome(string search)
        {
            throw new NotImplementedException();
        }

        public Home update(Home home)
        {
            return home;
        }
    }
}
