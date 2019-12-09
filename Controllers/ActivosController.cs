using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;


namespace CursoMVC.Controllers
{
    public class ActivosController : Controller
    {
        public ActionResult Index()
        {
            List<ActivosTableViewModels> lst = null;
            using (CursoMVCEntities db = new CursoMVCEntities())
            {
                lst = (from d in db.Activos
                       where d.idEstado == 1
                       orderby d.Serial

                       select new ActivosTableViewModels
                       {
                        
                           Id = d.Id,
                           Marca=d.Marca,
                           Serial=d.Serial,
                           Observaciones=d.Observaciones
                         
                       }).ToList();
            }

            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(ActivosViewModels model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CursoMVCEntities())
            {
                Activos oActivo = new Activos();
                oActivo.idEstado = 1;
                oActivo.Marca = model.Marca;
                oActivo.Serial = model.Serial;
                oActivo.Observaciones = model.Observaciones;
             

                db.Activos.Add(oActivo);

                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Activos/"));
        }

        public ActionResult Edit(int Id)
        {
            EditActivosViewModel model = new EditActivosViewModel();

            using (var db = new CursoMVCEntities())
            {
                var oActivo = db.Activos.Find(Id);
                model.Marca = oActivo.Marca;
                model.Serial = oActivo.Serial;
                model.Observaciones = oActivo.Observaciones;
                model.Id = oActivo.Id;


            }


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditActivosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CursoMVCEntities())
            {
                var oUser = db.Activos.Find(model.Id);
                oUser.Marca = model.Marca;
                oUser.Serial= model.Serial;
                oUser.Observaciones = model.Observaciones;

               

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/Activos/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new CursoMVCEntities())
            {
                var oUser = db.Activos.Find(Id);
                oUser.idEstado = 3; //eliminaremos

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }
    }
}