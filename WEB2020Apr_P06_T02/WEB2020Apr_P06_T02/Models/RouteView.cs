using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB2020Apr_P06_T02.Models
{
    public class RouteView
    {
        public List<FlightRoute> frList { get; set; }
        public List<ScheduleView> fsList { get; set; }
        public RouteView()
        {
            frList = new List<FlightRoute>();
            fsList = new List<ScheduleView>();
        }
    }
}
