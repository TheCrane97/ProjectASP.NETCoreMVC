using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Game.Helpers;

namespace Game.Controllers
{
    public class ArmyController : Controller
    {
        // GET: Army
        [Authorize(Roles = "admin, user")]
        public ActionResult Index()
        {
            GameEntities ent = new GameEntities();

            List<ArmyModel> army = new List<ArmyModel>();

            foreach (Army a in ent.Armies.ToList())
            {
                ArmyModel unit = new ArmyModel();
                unit.UnitId = a.Id;
                unit.Attack = a.Attack;
                unit.Defence = a.Defence;
                unit.KingdomId = a.KingdomId;
                unit.Knowledge = a.Knowledge;
                unit.MagicResist = a.MagicResist;
                unit.Name = a.Name;
                unit.Quantity = a.Quantity;
                
                army.Add(unit);

            }


            return View(army);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {

            ArmyModel a = new ArmyModel();
            GameEntities ent = new GameEntities();

            ViewData["Kingdom"] = ent.Kingdoms.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();

            return View("Create", a);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(ArmyModel a)
        {
            if (ModelState.IsValid)
            {
                GameEntities ent = new GameEntities();
                Army unit = new Army();

                unit.Name = a.Name;
                unit.Attack = a.Attack;
                unit.Defence = a.Defence;
                unit.KingdomId = a.KingdomId;
                unit.Knowledge = a.Knowledge;
                unit.MagicResist = a.MagicResist;
                unit.Quantity = a.Quantity;

                ent.Armies.Add(unit);
                ent.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                GameEntities ent = new GameEntities();

                ViewData["Kingdom"] = ent.Kingdoms.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();

                return View(a);
            }


        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int Id)
        {
            GameEntities ent = new GameEntities();
            ViewData["Kingdom"] = ent.Kingdoms.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
            ArmyModel model = ent.Armies.Where(x => x.Id == Id).FirstOrDefault().ToArmyViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(ArmyModel a)
        {


            if (ModelState.IsValid) // jezeli spelnia atrybuty, walidatory 
            {
                GameEntities ent = new GameEntities();
                Army unit;// = new Army();
                unit = ent.Armies.Where(x => x.Id == a.UnitId).FirstOrDefault();
                unit.Name = a.Name;
                unit.Attack = a.Attack;
                unit.Defence = a.Defence;
                unit.KingdomId = a.KingdomId;
                unit.Knowledge = a.Knowledge;
                unit.MagicResist = a.MagicResist;
                unit.Quantity = a.Quantity;
                ent.Entry(ent.Armies.Where(x => x.Id == a.UnitId).First()).CurrentValues.SetValues(unit);
                ent.SaveChanges();
                return RedirectToAction("Index");

            }

            else
            {
                GameEntities ent = new GameEntities();
                ViewData["Kingdom"] = ent.Kingdoms.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
                return View(a);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public ActionResult Details(int Id)
        {
            GameEntities ent = new GameEntities();
            ArmyModel unit = ent.Armies.Where(x => x.Id == Id).FirstOrDefault().ToArmyViewModel();
            return View(unit);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            GameEntities ent = new GameEntities();

            Army army = ent.Armies.Where(x => x.Id == id).First();
            ent.Armies.Remove(army);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}