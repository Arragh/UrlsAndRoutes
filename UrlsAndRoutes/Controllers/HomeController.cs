using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(nameof(Result), new Result { Controller = nameof(HomeController), Action = nameof(Index) });

        public ViewResult CustomVariable(string id)
        {
            Result result = new Result { Controller = nameof(HomeController), Action = nameof(CustomVariable) };
            result.Data["id"] = id ?? "<не задано>";
            return View(nameof(Result), result);
        }

        //public ViewResult CustomVariable()
        //{
        //    Result result = new Result { Controller = nameof(HomeController), Action = nameof(CustomVariable) };
        //    result.Data["id"] = RouteData.Values["id"];
        //    return View(nameof(Result), result);
        //}
    }
}
