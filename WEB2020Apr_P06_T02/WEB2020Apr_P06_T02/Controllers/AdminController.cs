using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using WEB2020Apr_P06_T02.DAL;
using WEB2020Apr_P06_T02.Models;

namespace WEB2020Apr_P06_T02.Controllers
{
    public class AdminController : Controller
    {
        private AdminDAL adContext = new AdminDAL();

        // GET: Admin
        public ActionResult Index()
        {
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            Staff ad = adContext.GetDetails(HttpContext.Session.GetString("LoginID"));
            return RedirectToAction("StaffMain");

        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*IFormCollection collection*/Staff staff)
        {
            if (ModelState.IsValid)
            {
                adContext.Add(staff);
                return RedirectToAction("StaffMain", "Home");
            }
            else
            {
                return View(staff);
            }

        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
        public ActionResult Viewpersonnel()
        {
            Staff staff = adContext.GetDetails(HttpContext.Session.GetString("LoginID"));

            return View(MapToPVM());
        }

        public List<PersonnelViewModel> MapToPVM()
        {
            List<PersonnelViewModel> pvmList = new List<PersonnelViewModel>();
            List<FlightCrew> crewlist = adContext.GetAllFlightCrew();
            List<Staff> stafflist = adContext.GetAllStaff();

            foreach (FlightCrew crew in crewlist)
            {
                foreach (Staff staff in stafflist)
                {
                    if (staff.StaffId == crew.StaffID)
                    {
                        pvmList.Add(
                            new PersonnelViewModel
                            {
                                ScheduleID = crew.ScheduleID,
                                StaffId = staff.StaffId,
                                StaffName = staff.StaffName,
                                Gender = staff.Gender,
                                DateEmployed = staff.DateEmployed,
                                Vocation = staff.Vocation,
                                Email = staff.Email,
                                Password = staff.Password,
                                Status = staff.Status,

                            }
                            );

                    }
                }
            }

            return pvmList;
        }
        public List<UpdateStatusViewModel> MapToUPM()
        {
            List<UpdateStatusViewModel> pvmList = new List<UpdateStatusViewModel>();
            List<FlightCrew> crewlist = adContext.GetAllFlightCrew();
            List<Staff> stafflist = adContext.GetAllStaff();

            //foreach (FlightCrew crew in crewlist)
            //{
            foreach (Staff staff in stafflist)
            {
                //if ()
                //{
                pvmList.Add(
                    new UpdateStatusViewModel
                    {

                        StaffId = staff.StaffId,
                        StaffName = staff.StaffName,
                        Gender = staff.Gender,

                        Vocation = staff.Vocation,
                        Email = staff.Email,

                        Status = staff.Status,

                    }
                    );

                //}
                //}
            }

            return pvmList;
        }



        public ActionResult UpdateStatus()
        {
            Staff staff = adContext.GetDetails(HttpContext.Session.GetString("LoginID"));

            return View(MapToUPM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(Staff staff)
        {
            ViewData["perSstatus"] = perSstatus;
            adContext.UpdateStatus(staff);
            return View(staff);
        }
        private List<SelectListItem> perSstatus = new List<SelectListItem>();
        private List<SelectListItem> role = new List<SelectListItem>();


        public AdminController()
        {
            perSstatus.Add(new SelectListItem
            {
                Text = "Active",
                Value = "Active"
            });
            perSstatus.Add(new SelectListItem
            {
                Text = "Inactive",
                Value = "Inactive"
            });

            role.Add(new SelectListItem
            {
                Text = "Flight Captain",
                Value = "Flight Captain"
            });
            role.Add(new SelectListItem
            {
                Text = "Second Pilot",
                Value = "Second Pilot"
            });
            role.Add(new SelectListItem
            {
                Text = "Cabin Crew Leader",
                Value = "Cabin Crew Leader"
            });
            role.Add(new SelectListItem
            {
                Text = "Flight Attendant",
                Value = "Flight Attendant"
            });
        }
        public ActionResult EditStatus(string id)
        {
            Staff staff = adContext.GetDetail(id);

            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["perSstatus"] = perSstatus;
                return View(staff);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStatus(Staff staff)
        {
            ViewData["perSstatus"] = perSstatus;
            adContext.UpdateStatus(staff);
            return RedirectToAction("ViewPersonnel");
        }

        public ActionResult ViewAssShedules(string id)
        {
            Staff staff = adContext.GetDetail(id);

            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["perSstatus"] = perSstatus;
                return View(staff);
            }

        }

        public ActionResult AssignView(int? id)
        {
            // Stop accessing the action if not logged in
            // or account not in the "Staff" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            AssignViewModel flightVM = new AssignViewModel();
            flightVM.FlightScheduleList = adContext.GetAllFlightSchedule();
            // BranchNo (id) present in the query string
            if (id != null)
            {
                ViewData["selectedScheduleId"] = id.Value;
                flightVM.FlightCrewList = adContext.GetScheduleStaff(id.Value);
            }
            else
            {
                ViewData["selectedScheduleId"] = "";
            }
            return View(flightVM);






            //public ActionResult UpdateStatus (string staffid)
            //{
            //    Staff staff = adContext.GetDetail(staffid);
            //    //if(staff.Vocation == "Administrator")
            //    //{
            //    //    return RedirectToAction();
            //    //}
            //    if (staff.Status == "Active")
            //    {
            //        staff.Status = "Inactive";
            //    }
            //    else if (staff.Status == "Inactive")
            //    {
            //        staff.Status = "Active";
            //    }
            //    adContext.UpdateStatus(staff);
            //    return View();
            //}
        }




        public ActionResult Change()
        {

            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["role"] = role;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change(FlightCrew flightcrew)
        {
            ViewData["role"] = role;
            adContext.Change(flightcrew);
            return RedirectToAction("AssignView");
        }
    }
}