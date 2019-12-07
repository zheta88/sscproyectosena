using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Acceso");
        }
    }
}   