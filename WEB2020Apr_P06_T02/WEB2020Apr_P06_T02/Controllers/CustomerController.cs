using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB2020Apr_P06_T02.DAL;
using WEB2020Apr_P06_T02.Models;

namespace WEB2020Apr_P06_T02.Controllers
{
    public class CustomerController : Controller
    {
        private CustDAL custContext = new CustDAL();
        private FlightDAL flightContext = new FlightDAL();
        // GET: Customer
        public ActionResult Index() 
        {
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Customer"))
            {
                return RedirectToAction("Index", "Home");
            }
            Customer cust = custContext.GetDetails(HttpContext.Session.GetString("LoginID"));
            List<Booking> bookingList = custContext.GetAllBookings();
            List<FlightViewModel> fvmList = new List<FlightViewModel>();   
            for(int i=0; i<bookingList.Count; i++)
            {
                if(bookingList[i].CustId == cust.CustId)
                {
                    List<Booking> bList = new List<Booking>();
                    bList.Add(bookingList[i]);
                    FlightViewModel fvm = new FlightViewModel
                    {
                        FlightSchedule = MapToFlightVM(bookingList[i].ScheduleId).FlightSchedule,
                        FlightRoute = MapToFlightVM(bookingList[i].ScheduleId).FlightRoute,
                        Booking = bList
                    };
                    fvmList.Add(fvm);
                }
            }
            return View(fvmList);
        }
        public FlightViewModel MapToFlightVM(int scheduleId)
        {
            List<FlightSchedule> scheduleList = flightContext.GetAllFlightSchedule();
            List<FlightRoute> routeList = flightContext.GetAllFlightRoute();
            FlightSchedule flightSchedule = new FlightSchedule();
            FlightRoute flightRoute = new FlightRoute();
            int routeId = 0;
            for (int x = 0; x < scheduleList.Count; x++)
            {
                if (scheduleList[x].ScheduleId == scheduleId)
                {
                    routeId = scheduleList[x].RouteId;
                    flightSchedule.ScheduleId = scheduleList[x].ScheduleId;
                    flightSchedule.FlightNumber = scheduleList[x].FlightNumber;
                    flightSchedule.RouteId = scheduleList[x].RouteId;
                    flightSchedule.AircraftId = scheduleList[x].AircraftId;
                    flightSchedule.DepartureDateTime = scheduleList[x].DepartureDateTime;
                    flightSchedule.ArrivalDateTime = scheduleList[x].ArrivalDateTime;
                    flightSchedule.EconomyClassPrice = scheduleList[x].EconomyClassPrice;
                    flightSchedule.BusinessClassPrice = scheduleList[x].BusinessClassPrice;
                    flightSchedule.Status = scheduleList[x].Status;
                    break;
                }
            }
            foreach (FlightRoute fr in routeList)
            {
                if (fr.RouteId == routeId)
                {
                    flightRoute.RouteId = fr.RouteId;
                    flightRoute.DepartureCity = fr.DepartureCity;
                    flightRoute.DepartureCountry = fr.DepartureCountry;
                    flightRoute.ArrivalCity = fr.ArrivalCity;
                    flightRoute.ArrivalCountry = fr.ArrivalCountry;
                    flightRoute.FlightDuration = fr.FlightDuration;
                    break;
                }
            }
            FlightViewModel flightVM = new FlightViewModel()
            {
                FlightRoute = flightRoute,
                FlightSchedule = flightSchedule
            };

            return flightVM;

        }
        public ActionResult Book(int id)
        {
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Customer"))
            {
                return RedirectToAction("Index", "Home");
            }
            FlightViewModel fvm = MapToFlightVM(id);
            HttpContext.Session.SetInt32("scheduleId", id); //Set the session scheduleid so that the system is able to obtain and know which is the specific flightschedule that the customer has selected
            return View(fvm);
        }
        [HttpPost]
        public ActionResult Book(FlightViewModel fvm)
        {
            int custId = custContext.GetDetails(HttpContext.Session.GetString("LoginID")).CustId;
            int scheduleId = HttpContext.Session.GetInt32("scheduleId").Value;
            FlightViewModel fvm2 = MapToFlightVM(scheduleId); //2nd fvm model for flightschedule and flightroute data
            if (!ModelState.IsValid)
            {
                return View(fvm2);
            }
            else 
            {
                for (int i = 0; i < HttpContext.Session.GetInt32("passengerNo"); i++)
                {
                    if (custContext.IsPassportExist(fvm.Booking[i].PassportNumber, scheduleId) == true) //check if the user is trying to input a passport that already exists for the same flightschedule
                    {
                        TempData["PassportExist"] = "Your passport number already exist for the same schedule. Please try with another passport number";
                    }
                    else
                    {
                        fvm.Booking[i].CustId = custId;
                        fvm.Booking[i].ScheduleId = scheduleId;
                        if (fvm.Booking[i].SeatClass == "Economy")
                        {
                            fvm.Booking[i].AmtPayable = fvm2.FlightSchedule.EconomyClassPrice;
                        }
                        else if (fvm.Booking[i].SeatClass == "Business")
                        {
                            fvm.Booking[i].AmtPayable = fvm2.FlightSchedule.BusinessClassPrice;
                        }
                        custContext.Book(fvm.Booking[i]);
                        if (i + 1 == HttpContext.Session.GetInt32("passengerNo"))
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    
                }
                return View(fvm2);
            }    
        }
        public IActionResult ChangePassword()
        {
            if ((HttpContext.Session.GetString("Role") == null) ||
            HttpContext.Session.GetString("Role") != "Customer")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(IFormCollection formData)
        {
            string currentPass = formData["currentPass"];
            string newPass = formData["newPass"];
            string confirmPass = formData["confirmPass"];
            Customer cust = custContext.GetDetails(HttpContext.Session.GetString("LoginID"));
            if((currentPass == cust.Password) && (newPass == confirmPass))
            {
                custContext.ChangePass(cust, newPass);
                TempData["Success"] = "Password changed successfully!";
            }
            else
            {
                TempData["Failure"] = "Please check your input again!";
            }
            return View();
        }

        public ActionResult PassengerBooking(int id)
        {
            List<Booking> passengerBook = new List<Booking>();
            List<Booking> bookingList = custContext.GetAllBookings();
            int scheduleId = 0;
            int custId = 0;
            foreach (Booking bookings in bookingList) //get the specific booking  details
            {
                if (bookings.BookingId == id)
                {
                    passengerBook.Add(bookings);
                    scheduleId = bookings.ScheduleId;
                    TempData["bookingID"] = bookings.BookingId;
                    custId = bookings.CustId;
                    break;
                }
            }
            FlightViewModel passengerFvm = new FlightViewModel()
            {
                FlightRoute = MapToFlightVM(scheduleId).FlightRoute,
                FlightSchedule = MapToFlightVM(scheduleId).FlightSchedule,
                Booking = passengerBook
            };
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Customer") ||
            (custContext.GetDetails(HttpContext.Session.GetString("LoginID")).CustId != custId))  //Check if the customer log in was the one who made the booking, if it is not return them to home index
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View(passengerFvm);
        }
    }
}