using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia1S2.Controllers
{
    public class VehiculosController : Controller
    {
        public IActionResult Consultar()
        {
            return View();
        }

        public IActionResult Actualizar()
        {
            return View();
        }


    }
}
