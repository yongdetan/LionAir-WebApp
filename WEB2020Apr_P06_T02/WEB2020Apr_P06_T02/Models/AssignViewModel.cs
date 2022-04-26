using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB2020Apr_P06_T02.Models
{
    public class AssignViewModel
    {
        public List<ScheduleView> FlightScheduleList { get; set; }
        public List<FlightCrew> FlightCrewList { get; set; }

        public AssignViewModel()
        {
            FlightScheduleList = new List<ScheduleView>();
            FlightCrewList = new List<FlightCrew>();
        }
    }
}
