﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaseballPlanner.Controllers
{
    public class AppExceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}