using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB2020Apr_P06_T02.Models
{
    public class FlightCrew
    {
        [Display(Name = "Schedule ID")]
        public int ScheduleID { get; set; }

        [Display(Name = "Staff ID")]
        public int StaffID { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }


    }
}
