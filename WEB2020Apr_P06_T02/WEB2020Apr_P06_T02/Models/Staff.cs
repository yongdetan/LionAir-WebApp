using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEB2020Apr_P06_T02.Models
{
    public class Staff
    {
        [Display(Name = "Staff ID")]
        public int StaffId { get; set; }

        [Display(Name = "Staff Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string StaffName { get; set; }

        [Display(Name = "Gender")]
        public char? Gender { get; set; }

        [Display(Name = "Date Employed")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateEmployed { get; set; }

        [Display(Name = "Vocation")]
        public string Vocation { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress]
        public  string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
