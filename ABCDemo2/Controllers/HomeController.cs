using ABCDemo2.Models.Demo1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCDemo2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Random rnd1 = new Random();
            int aLen = 12;
            int[] array1 = new int[aLen];
            int[] array2 = new int[aLen];
            int[] array3 = new int[aLen];
            for (int i = 0; i < aLen; i++)
            {
                array1[i] = rnd1.Next(0, 100);
                array2[i] = rnd1.Next(0, 100);
                array3[i] = rnd1.Next(0, 100);

            }
            ViewBag.Values1 = array1;
            ViewBag.Values2 = array2;
            ViewBag.Values3 = array3;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Jtable()
        {
            ViewBag.Message = "JTable test";
            return View();
        }

        [HttpPost]
        public JsonResult PersonList()
        {
            try
            {

                List<Persona> persons = new List<Persona>()
                {
                    new Persona(){
                        PersonId = 1,
                        Name = "Giuseppe",
                        Age = 36,
                        RecordDate = DateTime.Today
                    },
                    new Persona(){
                        PersonId = 2,
                        Name = "Pippo",
                        Age = 36,
                        RecordDate = DateTime.Today
                    }
                };
                return Json(new { Result = "OK", Records = persons });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreatePerson(Persona person)
        {
            try
            {
                Persona addedPerson = person;
                return Json(new { Result = "OK", Record = addedPerson });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdatePerson(Persona person)
        {
            try
            {
                return Json(new {Result = "OK"});
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeletePerson(int PersonId)
        {
            try
            {
                return Json(new {Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new {Result ="ERROR", Message = ex.Message });
            }
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Test VIEW";
            return View();
        }
    }
}