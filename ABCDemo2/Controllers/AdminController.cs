using ABCDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCDemo2.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (var context = new myOpDBEntities())
            {
                var query = from d in context.tblQualifiche
                            select d;
                var qualifiche = query.ToList();

                return View(qualifiche);
            }
        }

        public ActionResult Qualifiche()
        {

            return View();
        }

        #region Articoli
        public ActionResult Articoli()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ArticoliList()
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    var query = from a in context.tblArticoli
                                select(new {a.IDArticolo, a.CodiceArticolo, a.DescrizioneArticolo, a.WebLinkArticolo});

                    var articoli = query.ToList();

                return Json(new { Result = "OK", Records = articoli });
                }
            }
            catch (Exception Ex)
            {
                return Json(new { Result = "ERROR", Message = Ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ArticoliCreate(tblArticoli articolo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    context.tblArticoli.Add(articolo);
                    context.SaveChanges();
                }
                return Json(new { Result="OK", Record = articolo });
            }
            catch (Exception Ex)
            {
                return Json(new { Result = "ERROR", Message = Ex.Message});
            }

        }

        [HttpPost]
        public JsonResult ArticoliUpdate(tblArticoli articolo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    context.Entry(articolo).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    return Json(new { Result = "OK"});
                }

            }
            catch (Exception Ex)
            {
                return Json(new { Result = "ERROR", Message = Ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ArticoliDelete(tblArticoli articolo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    context.Entry(articolo).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();

                    return Json(new { Result = "OK" });
                }
            }
            catch (Exception Ex)
            {
                return Json(new { Result = "ERROR", Message = Ex.Message });
            }
        }
        #endregion
    }
}