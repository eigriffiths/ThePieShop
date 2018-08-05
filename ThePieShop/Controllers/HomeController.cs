using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThePieShop.Models;
using ThePieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThePieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepo _pireRepo;

        public HomeController(IPieRepo pieRepo)
        {
            _pireRepo = pieRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Pie Overview";

            var pies = _pireRepo.GetAllPies().OrderBy(p => p.Name);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to the Pie Shop",
                Pies = pies.ToList(),
            };

            return View(homeViewModel);
        }
    }
}
