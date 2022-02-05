using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia1S2.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Registrar()
        {
            return View();
        }
        public IActionResult Borrar()
        {
            return View();
        }
    }
}
