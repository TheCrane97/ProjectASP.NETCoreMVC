using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Validators
{
    public class MoreThanZero: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                var t = value.ToString();
                int number = Int32.Parse(t);
                
                if(number>=0)
                {
                    return ValidationResult.Success;
                }
                else
                
                return new ValidationResult("Number has to be bigger or equal 0.");

            }

            else
            {
                return ValidationResult.Success;
            }

        }
    }
}