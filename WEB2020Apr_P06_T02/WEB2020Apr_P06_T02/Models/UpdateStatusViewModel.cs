using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB2020Apr_P06_T02.Models
{
    public class UpdateStatusViewModel
    {

        [Display(Name = "Staff ID")]
        public int StaffId { get; set; }

        [Display(Name = "Staff Name")]
        public string StaffName { get; set; }

        [Display(Name = "Gender")]
        public char? Gender { get; set; }


        [Display(Name = "Vocation")]
        public string Vocation { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}

