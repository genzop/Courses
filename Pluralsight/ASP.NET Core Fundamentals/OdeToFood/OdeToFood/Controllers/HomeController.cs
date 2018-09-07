using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _RestaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _RestaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = _RestaurantData.GetAll();
            return View(model);
        }
    }
}
