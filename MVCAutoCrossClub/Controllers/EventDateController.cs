using BLL;
using MVCAutoCrossClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAutoCrossClub.Controllers
{
    public class EventDateController : Controller
    {
        //
        // GET: /EventDate/
        public ActionResult Index()
        {
            Logic log = new Logic();
            List<BLL.EventDateVM> Dates = log.GetAllEventDates();
            return View("EventDates", Dates);
        }

        //
        // GET: /EventDate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /EventDate/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EventDate/Create
        [HttpPost]
        public ActionResult Create(EventDateDB Date)
        {
            Logic logic = new Logic();
            EventDateVM mo = new EventDateVM();
            mo.id = Date.id;
            mo.Date = Date.Date ?? "";
            logic.CreateEventDate(mo);
            return RedirectToAction("EventDates");
        }

        //
        // GET: /EventDate/Edit/5
        public ActionResult Edit(int id)
        {
            Logic log = new Logic();
            EventDateVM Date = log.GetEventDateById(id);
            EventDateDB db = new EventDateDB(Date);
            return View(db);
        }

        //
        // POST: /EventDate/Edit/5
        [HttpPost]
        public ActionResult Edit(EventDateDB Date, FormCollection collection)
        {
            Logic log = new Logic();
            EventDateVM mo = new EventDateVM();

            mo.id = Date.id;
            mo.Date = Date.Date ?? "";
            log.UpdateEventDate(mo);
            return RedirectToAction("EventDates");
        }
        //
        // GET: /EventDate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /EventDate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
