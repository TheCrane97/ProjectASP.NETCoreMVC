using Game.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Models
{
    public class KingdomModel
    {

        public int Id { get; set; }


        [DisplayName("Name of Castle")]
        [Required(ErrorMessage = "Please enter the name of Castle.")]
        [FirstBigLetter]
        public string Name { get; set; }


        [DisplayName("Name of Kingdom")]
        [Required(ErrorMessage = "Please enter the name of Kingdom.")]
        [FirstBigLetter]
        public string Place { get; set; }


        [DisplayName("Population in Kingdom")]
        [Required(ErrorMessage = "Please enter population.")]
        [MoreThanZero]
        public int Population { get; set; }



    }
}