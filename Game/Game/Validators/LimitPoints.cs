using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Validators
{
    public class LimitPoints: ValidationAttribute
    {
        public string attack { get; set; }
        public string defence { get; set; }

        public LimitPoints(string a, string d)
        {
            attack = a;
            defence = d;
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            int a = (int)(properties.Find(attack, true).GetValue(value));
            int d = (int)(properties.Find(defence, true).GetValue(value));


            if (a>=d)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}