﻿using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
