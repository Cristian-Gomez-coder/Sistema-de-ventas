﻿using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}