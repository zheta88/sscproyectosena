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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModels> lst = null;
            using (CursoMVCEntities db=new CursoMVCEntities())
            {
                lst = (from d in db.User
                      where d.idState == 1
                      orderby d.nombre
                      select new UserTableViewModels
                      {
                          Email = d.email,
                          Id=d.id,
                          Nombre=d.nombre,
                          Telefono=d.telefono


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
        public ActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CursoMVCEntities())
            {
                User oUser = new User();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.password = model.Password;
                oUser.nombre = model.Nombre;
                oUser.telefono = model.Telefono;

                db.User.Add(oUser);

                db.SaveChanges();

            }

            return Redirect(Url.Content("~/User/"));
        }

         public ActionResult Edit (int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db=new CursoMVCEntities())
            {
                var oUser = db.User.Find(Id);
                model.Nombre = oUser.nombre;
                model.Telefono = oUser.telefono;
                model.Email = oUser.email;
                model.Id = oUser.id;


            }


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CursoMVCEntities())
            {
                var oUser = db.User.Find(model.Id);
                oUser.email = model.Email;
                oUser.nombre = model.Nombre;
                oUser.telefono = model.Telefono;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new CursoMVCEntities())
            {
                var oUser = db.User.Find(Id);
                oUser.idState = 3; //eliminaremos

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }

    }
    }