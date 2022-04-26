using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEB2020Apr_P06_T02.Models
{
    public class Customer
    {
        public int CustId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters are allowed.")] //validation to check if user inputs non-alphabetical value
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters are allowed.")] //validation to check if user inputs non-alphabetical value

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Telephone Number")]
        [RegularExpression(@"^\+((?:9[679]|8[035789]|6[789]|5[90]|42|3[578]|2[1-689])|9[0-58]|8[1246]|6[0-6]|5[1-8]|4[013-9]|3[0-469]|2[70]|7|1)(?:\W*\d){0,13}\d$", ErrorMessage = "Invalid Phone Number. Please include country and area code, e.g. +6598765432")]
        public string TelNo { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email address format. Please check your input and try again.")]
        // Custom Validation Attribute for checking email address exists
        [ValidateEmailExists]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }
    }
}
