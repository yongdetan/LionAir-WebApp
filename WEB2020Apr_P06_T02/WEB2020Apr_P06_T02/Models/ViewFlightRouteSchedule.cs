using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEB2020Apr_P06_T02.Models
{
    public class ViewFlightRouteSchedule
    {
        [Display(Name = "Route ID")]
        [Required]
        public int RouteId { get; set; }

        [Display(Name = "Schedule ID")]
        [Required]
        public int ScheduleId { get; set; }

    }
}
