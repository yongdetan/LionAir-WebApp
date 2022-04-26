using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB2020Apr_P06_T02.DAL;
using WEB2020Apr_P06_T02.Models;

namespace WEB2020Apr_P06_T02.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route        
        private RouteDAL routeContext = new RouteDAL();
        public ActionResult Index(int? id)
        {
            // Stop accessing the action if not logged in
            // or account not in the "Staff" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            RouteView RouteVM = new RouteView();
            RouteVM.frList = routeContext.GetAllFlightRoute();
            // riute (id) present in the query string
            if (id != null)
            {
                ViewData["selectedRouteID"] = id.Value;
                RouteVM.fsList = routeContext.GetSchedule(id.Value);
            }
            else
            {
                ViewData["selectedRouteID"] = "";
            }
            return View(RouteVM);
        }


        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult CreateRoute()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoute(FlightRoute FR)
        {
            
            if (ModelState.IsValid)
            {
                //this is to check for existing route in database.
                bool existroute = routeContext.CheckExistRoute(FR);
                if (existroute)
                {
                    TempData["ErrorRouteExisted"] = "Route existed, please try again.";
                    return View(FR);
                }

                if (FR.ArrivalCity != FR.DepartureCity)
                {
                    //Add route into database
                    FR.RouteId = routeContext.Add(FR);
                    //Redirect user to admin/Index view
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorArrival"] = "Arrival city cannot be the same as Departure city.";
                    TempData["ErrorDeparture"] = "Departure city cannot be the same as Arrival city.";
                    return View(FR);
                }
            }
            else
            {
                //Input validation fails, return to the Create view
                //to display error message
                return View();
            }
        }


        // POST: Route/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Route/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Route/Delete/5
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