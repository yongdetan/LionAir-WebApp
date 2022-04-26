using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace WEB2020Apr_P06_T02.Models
{
    public class ScheduleView
    {
        [Display(Name = "Schedule ID")]
        public int ScheduleId { get; set; }

        [Display(Name = "Flight Number")]
        [RegularExpression("^[L][C][0-9]*$", ErrorMessage = "Please start with LC letters (Eg. LC001).")]
        [Required]
        [StringLength(20)]
        public string FlightNumber { get; set; }

        [Display(Name = "Route ID")]
        [Required]
        public int RouteId { get; set; }

        [Display(Name = "Aircraft ID")]
        [Range(1, 9999999999999999, ErrorMessage = "Value should be greater than or equal to 1")]
        public int? AircraftId { get; set; }

        [ValidateDDT]
        [Display(Name = "Departure Date Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime? DepartureDateTime { get; set; }

        [Display(Name = "Arrival Date Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ArrivalDateTime { get; set; }

        [Display(Name = "Economy Class Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Value should be greater than or equal to 0")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]

        public decimal EconomyClassPrice { get; set; }

        [Display(Name = "Business Class Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Value should be greater than or equal to 0")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal BusinessClassPrice { get; set; }

        [Display(Name = "Status")]
        [StringLength(20)]
        public string Status { get; set; }

        [Display(Name = "Ticket Bookings")]
        public int Ticket { get; set; }
    }
}
