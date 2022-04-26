using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB2020Apr_P06_T02.Models
{
    public class PersonnelViewModel
    {
        
            [Display(Name = "Schedule ID")]
            public int ScheduleID { get; set; }

            [Display(Name = "Staff ID")]
            public int StaffId { get; set; }

            [Display(Name = "Staff Name")]
            public string StaffName { get; set; }

            [Display(Name = "Gender")]
            public char? Gender { get; set; }

            [Display(Name = "Date Employed")]
            [DataType(DataType.Date)]
            public DateTime? DateEmployed { get; set; }

            [Display(Name = "Vocation")]
            public string Vocation { get; set; }

            [Display(Name = "Email Address")]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }
 
        //public FlightCrew FlightCrew { get; set; }
        //public Staff Staff { get; set; }
    }
}