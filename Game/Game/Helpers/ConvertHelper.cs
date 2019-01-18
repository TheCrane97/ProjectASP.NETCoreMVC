using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game.Helpers
{
    public static class ConvertHelper
    {
        public static KingdomModel ToKingdomViewModel(this Kingdom kingdom)
        {
            KingdomModel k = new KingdomModel();
            k.Id = kingdom.Id;
            k.Name = kingdom.Name;
            k.Place = kingdom.Place;
            k.Population = kingdom.Population;
           
            return k;
        }



        public static ArmyModel ToArmyViewModel(this Army army)
        {
            ArmyModel a = new ArmyModel();
            a.UnitId = army.Id;
            a.Name = army.Name;
            a.Attack = army.Attack;
            a.Defence = army.Defence;
            a.Knowledge = army.Knowledge;
            a.MagicResist = army.MagicResist;
            a.Quantity = army.Quantity;
            a.KingdomId = army.KingdomId;
            return a;

        }

    }
}