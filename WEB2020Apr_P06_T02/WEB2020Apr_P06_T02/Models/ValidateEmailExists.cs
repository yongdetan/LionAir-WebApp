using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WEB2020Apr_P06_T02.DAL;

namespace WEB2020Apr_P06_T02.Models
{
    public class ValidateEmailExists : ValidationAttribute
    {
        private CustDAL custContext = new CustDAL();
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            // Get the email value to validate
            string email = Convert.ToString(value);
            // Casting the validation context to the "Customer" model class
            Customer customer = (Customer)validationContext.ObjectInstance;
            // Get the Customer Id from the staff instance
            int custId = customer.CustId;
            if (custContext.IsEmailExist(email, custId))
                // validation failed
                return new ValidationResult
                ("Email address already exists!");
            else
                // validation passed
                return ValidationResult.Success;
        }
    }
}
