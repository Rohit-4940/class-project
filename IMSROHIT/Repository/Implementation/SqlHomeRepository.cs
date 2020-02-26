using IMSROHIT.Models;
using IMSROHIT.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSROHIT.Repository.Implementation
{
    public class SqlHomeRepository : IHome
    {
        private readonly Databases _context;
        public SqlHomeRepository(Databases context)
        {
            this._context = context;
        }
        public Home add(Home home)
        {
            _context.homes.Add(home);
            _context.SaveChanges();
            return home;
        }
        
        public Home Delete(int id)
        {
            Home hm = _context.homes.Find(id);
            if (hm != null)
            {
                _context.homes.Remove(hm);
                _context.SaveChanges();
            }
            return hm;
        }

        public IEnumerable<Home> GetAllHome()
        {
            return _context.homes;
        }

        public Home GetHome(int id)
        {
            return _context.homes.Find(id);
        }

        public List<Home> SearchHome(string search)
        {
            return _context.homes.Where(p => p.Name.Contains(search)
            || p.Email.Contains(search) || p.Department.Contains(search)).ToList();

        }

        public Home update(Home home)
        {
            var hn = _context.homes.Attach(home);
            hn.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return home;
        }
    }
}
