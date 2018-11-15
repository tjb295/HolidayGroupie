using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolidayGroupie.Models
{
    public class ComparePassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            if(user.PasswordCheck == "")
            {
                return new ValidationResult("Please retype password");
            }
            if(user.Password == user.PasswordCheck && user.PasswordCheck != "")
            {
                return ValidationResult.Success;
            }
            else if(user.Password != user.PasswordCheck)
            {
                return new ValidationResult("Passwords do not match");
            }
            else if (user.PasswordCheck == null)
                return new ValidationResult("Please confirm password.");

            return new ValidationResult("Passwords do not match");
        }
    }
}