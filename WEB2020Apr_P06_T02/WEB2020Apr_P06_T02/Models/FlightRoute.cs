using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEB2020Apr_P06_T02.Models
{
    public class FlightRoute
    {
        [Display(Name = "Route ID")]
        [Required]
        public int RouteId { get; set; }

        [Display(Name = "Departure City")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [StringLength(50)]
        public string DepartureCity { get; set; }

        [Display(Name = "Departure Country")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [StringLength(50)]
        public string DepartureCountry { get; set; }

        [Display(Name = "Arrival City")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [StringLength(50)]
        public string ArrivalCity { get; set; }

        [Display(Name = "Arrival Country")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [StringLength(50)]
        public string ArrivalCountry { get; set; }

        [Display(Name = "Flight Duration")]
        [Range(1, 50, ErrorMessage = "Value should be greater than or equal to 1")]
        public int FlightDuration { get; set; }

    }
}
