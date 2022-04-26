using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEB2020Apr_P06_T02.Models
{
    public class FlightViewModel
    {
        public FlightRoute FlightRoute {get; set;}
        public FlightSchedule FlightSchedule {get; set;}
        public List<Booking> Booking { get; set; }

    }
}
