using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using WEB2020Apr_P06_T02.DAL;
using WEB2020Apr_P06_T02.Models;

namespace WEB2020Apr_P06_T02.Controllers
{
    public class ScheduleController : Controller
    {
        private ScheduleDAL sContext = new ScheduleDAL();
        private RouteDAL rContext = new RouteDAL();
        private List<FlightRoute> GetAllFlightRoute()
        {
            // Get a list of branches from database
            List<FlightRoute> frList = rContext.GetAllFlightRoute();
            // Adding a select prompt at the first row of the branch list
            return frList;
        }
        //Create a list for flightstatue
        private List<SelectListItem> flightstatus = new List<SelectListItem>();


        public ScheduleController()
        {
            // add all the options into list
            flightstatus.Add(new SelectListItem{
                    Text = "Full",Value = "Full"});
            flightstatus.Add(new SelectListItem{
                    Text = "Delayed",Value = "Delayed"});
            flightstatus.Add(new SelectListItem{
                    Text = "Cancelled",Value = "Cancelled"});
            flightstatus.Add(new SelectListItem{
                    Text = "Opened",Value = "Opened"});

        }
        // GET: Schedule
        public ActionResult Index()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            List<ScheduleView> schList = sContext.GetAllFSchedule();
            return View(schList);

        }

        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schedule/Create
        public ActionResult CreateSchedule()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Staff" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["frList"] = GetAllFlightRoute();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSchedule(ScheduleView Schedule)
        {
            //Is to view all flight route
            ViewData["frList"] = GetAllFlightRoute();
            FlightRoute route = sContext.GetDuration(Schedule.RouteId);
            if (ModelState.IsValid)
            {
                //validation on business must be higher price that economy
                if(Schedule.BusinessClassPrice > Schedule.EconomyClassPrice)
                {
                    Schedule.ArrivalDateTime = Schedule.DepartureDateTime.Value.AddHours(route.FlightDuration);
                    //Add Schedule record to database
                    Schedule.ScheduleId = sContext.Add(Schedule);
                    //Redirect user to Admin/Index view
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Business Class Price must be higher than Economy Class Price.";
                    return View(Schedule);
                }
               
            }
            else
            {
                //Input validation fails, return to the Create view
                //to display error message
                return View(Schedule);
            }
        }

        // POST: Schedule/Create


        // GET: Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            // Stop accessing the action if not logged in
            // or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            { //Query string parameter not provided
              //Return to listing page, not allowed to edit
                return RedirectToAction("Index");
            }
            ViewData["flightstatus"] = flightstatus;
            ScheduleView Schedule = sContext.GetDetails(id.Value);

            if (Schedule == null)
            {
                //Return to listing page, not allowed to edit
                return RedirectToAction("Index");
            }
            return View(Schedule);
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScheduleView Schedule)
        {
            ViewData["flightstatus"] = flightstatus;
            sContext.Update(Schedule);
            return RedirectToAction("Index");




        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Schedule/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}