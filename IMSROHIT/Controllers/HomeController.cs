using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSROHIT.Models;
using IMSROHIT.Repository.Interface;
using IMSROHIT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IMSROHIT.Repository.Implementation;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSROHIT.Controllers
{ 
    public class HomeController : Controller
    {
       
        private IHome _employeerepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IHome employeerepository,IHostingEnvironment hostingEnvironment)
        {
            _employeerepository = employeerepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ViewResult design(string search = null)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var searchbar = _employeerepository.SearchHome(search);
                return View(searchbar);
            }

            var model = _employeerepository.GetAllHome();
            return View(model);

        }
        public IActionResult design1(int? id)
        {
            Home emp = _employeerepository.GetHome(id??1);
            HomeViewModel em = new HomeViewModel();
            em.Title = "Employee List";
            em.Date = DateTime.Now;
            em.employees = emp;
            return View(em);
        }
        public IActionResult login()
        {

            return View();
        }
        [HttpGet]
        
        public ViewResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(HomecreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);
                Home home = new Home
                {
                    Name = model.Name,
                    Email=model.Email,
                    Department=model.Department,
                    photopath=uniqueFileName
                };
                _employeerepository.add(home);
                return RedirectToAction("design", new {id=  home.id });
            }
            return View();
        }

        public ViewResult index()
        {
            
            var model = _employeerepository.GetAllHome();
            return View(model);
           
        }
        public IActionResult dashboard()
        {
            return View();
        }
        public IActionResult signup()
        {
            return View();
        }
        public ViewResult detail(int? id)
        {
            HomedetailViewModel homedetailViewModel = new HomedetailViewModel()
            {
                home=_employeerepository.GetHome(id??1)
            };
            return View(homedetailViewModel);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            Home home = _employeerepository.GetHome(id);
            HomeeditViewModel homeeditViewModel = new HomeeditViewModel()
            {
                Id=home.id,
                Name=home.Name,
                Email=home.Email,
                Department=home.Department,
                Existingphoto=home.photopath
            };
            return View(homeeditViewModel);
        }
        [HttpPost]
        public IActionResult edit(HomeeditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Home homes = _employeerepository.GetHome(model.Id);
                homes.Name = model.Name;
                homes.Email = model.Email;
                homes.Department = model.Department;
                if (model.photos != null)
                {
                    if (model.Existingphoto !=null)
                    {
                        string filepath=Path.Combine(hostingEnvironment.WebRootPath, 
                            "images", model.Existingphoto);
                        System.IO.File.Delete(filepath);
                    }
                    homes.photopath = ProcessUploadFile(model);
                }
                _employeerepository.update(homes);

                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadFile(HomecreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.photos != null && model.photos.Count>0)
            {
                foreach (IFormFile photo in model.photos) { 
                string UpLoadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filepath = Path.Combine(UpLoadsFolder, uniqueFileName);
               photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }
           }

            return uniqueFileName;
        }

        public IActionResult delete(int id)
        {
            Home hm = _employeerepository.Delete(id);
            return View();
        }




    }
}

