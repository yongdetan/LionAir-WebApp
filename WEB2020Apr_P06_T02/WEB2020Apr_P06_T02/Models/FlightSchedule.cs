using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace WEB2020Apr_P06_T02.Models
{
    public class FlightSchedule
    {
        [Display(Name = "Schedule ID")]
        [Required]
        public int ScheduleId { get; set; }

        [Display(Name = "Flight Number")]
        [Required]
        [StringLength(20)]
        public string FlightNumber { get; set; }

        [Display(Name = "Route ID")]
        [Required]
        public int RouteId { get; set; }

        [Display(Name = "Aircraft ID")]
        [Required]
        public int AircraftId { get; set; }

        [Display(Name = "Departure Date Time")]
        public DateTime DepartureDateTime { get; set; }

        [Display(Name = "Arrival Date Time")]
        public DateTime ArrivalDateTime { get; set; }

        [Display(Name = "Economy Class Price")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal EconomyClassPrice { get; set; }

        [Display(Name = "Business Class Price")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal BusinessClassPrice { get; set; }

        [Display(Name = "Status")]
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}
