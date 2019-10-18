using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlzaWebApi.V1.Controllers
{
    /// <summary>
    /// Produkty
    /// </summary>
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}