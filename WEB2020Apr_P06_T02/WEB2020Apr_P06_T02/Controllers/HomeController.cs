using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using WEB2020Apr_P06_T02.DAL;
using WEB2020Apr_P06_T02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Routing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Loader;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WEB2020Apr_P06_T02.Controllers
{
    public class HomeController : Controller
    {
        private CustDAL custContext = new CustDAL();
        private FlightDAL flightContext = new FlightDAL();
        private AdminDAL adContext = new AdminDAL();

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private List<SelectListItem> GetCountries()
        {
            List<SelectListItem> originList = new List<SelectListItem>();
            List<string> duplicateCheck = new List<string>(); //Check if country already exists in the list
            foreach (var item in flightContext.GetAllFlightRoute())
            {
                if(!duplicateCheck.Contains(item.ArrivalCountry))
                {
                    originList.Add(new SelectListItem { Value = item.ArrivalCountry, Text = item.ArrivalCountry });
                    duplicateCheck.Add(item.ArrivalCountry);
                }
            }
            return originList;
        }
        public IActionResult Index()
        {
            ViewData["Countries"] = GetCountries();
            return View();
        }

        [HttpPost]
        public ActionResult Search(IFormCollection formData)
        {
            List<FlightViewModel> fvmList = new List<FlightViewModel>();
            //Use TempData to display the departure and arrival country searched
            TempData["DepartureCountry"] = formData["DepartureCountry"];  
            TempData["ArrivalCountry"] = formData["ArrivalCountry"];

            string origin = formData["DepartureCountry"];
            string destination = formData["ArrivalCountry"];
            int passengerNo = Convert.ToInt32(formData["PassengerNo"]);
            if (passengerNo <= 0) //check if user input negative/0 passengers
            {
                TempData["Message"] = "There must be at least 1 passenger!";
                return RedirectToAction("Index");
            }

            if (flightContext.getRoute(origin, destination) != -1)
            {
                HttpContext.Session.SetInt32("passengerNo", passengerNo);
                return View(MapToFlightVM(flightContext.getRoute(origin, destination)));
            }

            return View();
        }

        public List<FlightViewModel> MapToFlightVM(int routeId)
        {
            List<FlightViewModel> fvmList = new List<FlightViewModel>();
            List<FlightSchedule> scheduleList = flightContext.GetAllFlightSchedule();
            List<FlightRoute> routeList = flightContext.GetAllFlightRoute();
            FlightRoute flightRoute = new FlightRoute();
            for (int i=0; i<routeList.Count; i++)
            {
                if (routeList[i].RouteId == routeId)
                {
                    flightRoute.RouteId = routeList[i].RouteId;
                    flightRoute.DepartureCity = routeList[i].DepartureCity;
                    flightRoute.DepartureCountry = routeList[i].DepartureCountry;
                    flightRoute.ArrivalCity = routeList[i].ArrivalCity;
                    flightRoute.ArrivalCountry = routeList[i].ArrivalCountry;
                    flightRoute.FlightDuration = routeList[i].FlightDuration;
                }
            }
            for(int x=0; x<scheduleList.Count; x++)
            {
                if(scheduleList[x].RouteId == routeId)
                {
                    FlightSchedule flightSchedule = new FlightSchedule()
                    {
                        ScheduleId = scheduleList[x].ScheduleId,
                        FlightNumber = scheduleList[x].FlightNumber,
                        RouteId = scheduleList[x].RouteId,
                        AircraftId = scheduleList[x].AircraftId,
                        DepartureDateTime = scheduleList[x].DepartureDateTime,
                        ArrivalDateTime = scheduleList[x].ArrivalDateTime,
                        EconomyClassPrice = scheduleList[x].EconomyClassPrice,
                        BusinessClassPrice = scheduleList[x].BusinessClassPrice,
                        Status = scheduleList[x].Status
                    };
                    FlightViewModel flightVM = new FlightViewModel()
                    {
                        FlightRoute = flightRoute,
                        FlightSchedule = flightSchedule
                    };
                    fvmList.Add(flightVM);
                }
            }
            return fvmList;
        }
 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] //POST is used to send data to a server to create/update a resource.
        public ActionResult Login(IFormCollection formData) //action method
        {
            string loginID = formData["txtLoginID"];
            string password = formData["txtPassword"];
            if (custContext.IsAccExist(loginID, password) == true)
            {
                // Store Login ID in session with the key “LoginID”
                HttpContext.Session.SetString("LoginID", loginID);     
                // Store user role “Customer” as a string in session with the key “Role”
                HttpContext.Session.SetString("Role", "Customer");
                return RedirectToAction("Index", "Customer");
            }
            else if (adContext.IsAccExist(loginID, password) == true)
            {
                    HttpContext.Session.SetString("LoginID", loginID);
                    // Store user role “Admin” as a string in session with the key “Role”
                    HttpContext.Session.SetString("Role", "Admin");
                    return RedirectToAction("StaffMain");
            }
            else
            {
                // Store an error message in TempData for display at the index view
                TempData["Message"] = "Invalid Login Credentials!";
                // Redirect user back to the index view through an action
                return View();
            }
        }
        public ActionResult StaffMain()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            // Clear all key-values pairs stored in session state
            HttpContext.Session.Clear();
            // Call the Index action of Home controller
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                //Add customer record to database
                custContext.Add(cust);
                //Redirect user to Home/Index view
                return RedirectToAction("Index");
            }
            else
            {
                return View(cust);
            }
        }

        public async Task<ActionResult> Countryinformation()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://restcountries.eu");
            HttpResponseMessage response = await client.GetAsync("/rest/v2/all");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<CountryInformation> bookList = JsonConvert.DeserializeObject<List<CountryInformation>>(data);
                return View(bookList);
            }
            else
            {
                return View(new List<CountryInformation>());
            }
        }
        public async Task<ActionResult> CountryDetails(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://restcountries.eu");
            HttpResponseMessage response = await client.GetAsync("/rest/v2/name/" + id);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<CountryInformation> bookList = JsonConvert.DeserializeObject<List<CountryInformation>>(data);
                return View(bookList);
            }
            else
            {
                return View(new List<CountryInformation>());
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
