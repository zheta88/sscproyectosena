﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;

namespace CursoMVC.Filters
{
    public class VerificarSesion: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (User)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}