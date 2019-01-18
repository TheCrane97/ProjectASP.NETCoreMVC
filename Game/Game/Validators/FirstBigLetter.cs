using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Game.Validators
{
    public class FirstBigLetter: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                var t = value.ToString();
                

               
                
                    if (Regex.IsMatch(t, "^[A-ZŻŹĆĄŚĘŁÓŃ][a-zzżźćńółęą ]{2,}$"))
                    {
                    return ValidationResult.Success;
                }
                else

                    return new ValidationResult("First letter has to be big. At least 2 letters. Numbers are forbidden.");
                
            }

            else
            {
                return ValidationResult.Success;
            }

        }
    }
}