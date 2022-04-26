using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEB2020Apr_P06_T02.Models
{
    public class Booking
    {
        [Required]
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Required]
        public int CustId { get; set; }

        [Required]
        [Display(Name = "Schedule ID")]
        public int ScheduleId { get; set; }

        [Required]
        [Display(Name = "Passenger Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please make sure your input matches your name as printed on passport.")] //validation to check if user inputs non-alphabetical value
        [StringLength(50)]
        public string PassengerName { get; set; }

        [Required]
        [Display(Name = "Passport Number")]
        [RegularExpression(@"^(?!^0+$)[a-zA-Z0-9]{6,9}$", ErrorMessage = "Please make sure your input passport number is valid. E.g. E1234567A.")] 
        [StringLength(20)]
        public string PassportNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters are allowed.")] //validation to check if user inputs non-alphabetical value
        [StringLength(50)]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "Seat Class")]
        [StringLength(20)]
        public string SeatClass { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal AmtPayable { get; set; }

        [StringLength(3000)]
        public string Remarks { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; }
    }
}
