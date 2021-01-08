using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() => View(nameof(Result), new Result { Controller = nameof(AdminController), Action = nameof(Index) });
    }
}
