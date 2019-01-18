using Game.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Game.Models
{

    [LimitPoints("Attack", "Defence", ErrorMessage = "Points of Damage always has to be more (or equal) than Defence.")]

    public class ArmyModel
    {
        
        public int UnitId { get; set; }

        [DisplayName("Name of Unit")]
        [Required(ErrorMessage = "Please enter Name of Unit.")]
        [FirstBigLetter]
        public string Name { get; set; }

        [DisplayName("Points of Damage")]
        [Required(ErrorMessage = "Please enter Points of Damage.")]
        [MoreThanZero]
        public int Attack { get; set; }

        [DisplayName("Points of Defence")]
        [Required(ErrorMessage = "Please enter Points of Defence.")]
        [MoreThanZero]
        public int Defence { get; set; }

        [DisplayName("Points of Magic Resist")]
        [Required(ErrorMessage = "Please enter Points of Magic Resist.")]
        [MoreThanZero]
        public int MagicResist { get; set; }

        [DisplayName("Points of Knowledge")]
        [Required(ErrorMessage = "Please enter Points of Knowledge.")]
        [MoreThanZero]
        public int Knowledge { get; set; }

        [DisplayName("Amount of Units")]
        [Required(ErrorMessage = "Please enter Amount of Units.")]
        [MoreThanZero]
        public int Quantity { get; set; }

        [DisplayName("Kingdom that Unit belongs")]
        [Required(ErrorMessage = "Choose Kingdom.")]
        public int? KingdomId { get; set; }

        
        [DisplayName(displayName: "Kingdom that Unit belongs")]
        public Kingdom kingdom
        {
            get
            {

                GameEntities ent = new GameEntities();
                return ent.Kingdoms.Where(x => x.Id == KingdomId).FirstOrDefault();

            }
        }



        [Display(Name = "Amount of Damage")]
        public int AmountOfDamage
        {
            set { }
            get
            {
                GameEntities ent = new GameEntities();
                int number = ent.Armies.Where(x => x.Id == UnitId).Select(x => x.Attack * x.Quantity).FirstOrDefault();

                return number; 
            }

        }

    }
}