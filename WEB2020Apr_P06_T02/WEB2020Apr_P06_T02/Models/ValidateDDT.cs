using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WEB2020Apr_P06_T02;

namespace WEB2020Apr_P06_T02.Models
{
    public class ValidateDDT: ValidationAttribute
    {
        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            

            if (dateValue.Date < DateTime.Now.Date.AddHours(24))
            {
                return new ValidationResult("Departure Date Time Value must be one day later");
            }
            else
            {
                return ValidationResult.Success;
            }

           
            
        }
    }
}
