using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
            
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (CursoMVCEntities db= new CursoMVCEntities())
                {
                    var lst = from d in db.User
                              where d.email == user && d.password == password && d.idState==1
                              select d;

                    if (lst.Count()>0)
                    {
                        User oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1"); 
                    }
                    else
                    {
                        return Content("Usuario Inválido");

                    }
                }

            }
            catch (Exception ex)
            {

                return Content("Ocurrió un error"+ex.Message);
            }
          
        }


    }
} 