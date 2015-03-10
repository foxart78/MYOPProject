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
        public JsonResult ArticoliList(
            int jtStartIndex = 0,
            int jtPageSize = 0)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    var query = from a in context.tblArticoli
                                orderby(a.IDArticolo)
                                select(new {a.IDArticolo, a.CodiceArticolo, a.DescrizioneArticolo, a.WebLinkArticolo});


                    var articoli = query.Skip(jtStartIndex).Take(jtPageSize).ToList();

                    int countArticoli = context.tblArticoli.Count();

                    return Json(new { Result = "OK", Records = articoli, TotalRecordCount = countArticoli });
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

        #region Prezzi
        [HttpPost]
        public JsonResult PrezziList(int IDArticolo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    var query = from p in context.tblArticoliPrezzi
                                where p.IDArticolo == IDArticolo
                                select (new { p.IDArticolo, p.IDArticoloPrezzo, p.TipoPrezzo, p.Prezzo, p.DescrizionePrezzo });

                    var prezzi = query.ToList();
                    return Json(new { Result = "OK", Records = prezzi });
                }
            }
            catch (Exception Ex)
            {
                return Json(new { Result = "ERROR", Message = Ex.Message });
            }
        }

        [HttpPost]
        public JsonResult PrezziCreate(tblArticoliPrezzi ArticoloPrezzo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    context.tblArticoliPrezzi.Add(ArticoloPrezzo);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = ArticoloPrezzo });
                }
            }
            catch (Exception Ex)
            {
                return Json(new { Result = "ERROR", Message = Ex.Message });
            }
        }
        [HttpPost]
        public JsonResult PrezziUpdate(tblArticoliPrezzi ArticoloPrezzo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    context.Entry(ArticoloPrezzo).State = System.Data.Entity.EntityState.Modified;
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
        public JsonResult PrezziDelete(tblArticoliPrezzi ArticoloPrezzo)
        {
            try
            {
                using (var context = new myOpDBEntities())
                {
                    context.Entry(ArticoloPrezzo).State = System.Data.Entity.EntityState.Deleted;
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