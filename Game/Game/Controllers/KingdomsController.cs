using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Game.Models;
using Game.Helpers;

namespace Game.Controllers
{
    public class KingdomsController : Controller
    {

        // GET: Kingdoms
        [Authorize(Roles = "admin, user")]
        public ActionResult Index()
        {
            GameEntities ent = new GameEntities();

            List < KingdomModel > kingdom = new List<KingdomModel>();

            foreach( Kingdom k in ent.Kingdoms.ToList() )
            {
                KingdomModel king = new KingdomModel();
                king.Id = k.Id;
                king.Name = k.Name;
                king.Place = k.Place;
                king.Population = k.Population;

                kingdom.Add(king);

            }


            return View(kingdom);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create() {

            KingdomModel k = new KingdomModel();
            return View(k);
  
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(KingdomModel k)
        {
            if (ModelState.IsValid)
            {
                GameEntities ent = new GameEntities();
                Kingdom king = new Kingdom();
                king.Name = k.Name;
                king.Place = k.Place;
                king.Population = k.Population;

                ent.Kingdoms.Add(king);
                ent.SaveChanges();


                return RedirectToAction("Index");
            }
            else {
                return View(k);
            }


        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int Id)
        {
            GameEntities ent = new GameEntities();
            KingdomModel kingdom = ent.Kingdoms.Where(x => x.Id == Id).FirstOrDefault().ToKingdomViewModel();

            return View(kingdom);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(KingdomModel kingdom)
        {
            if (ModelState.IsValid) // jezeli spelnia atrybuty, walidatory np. Required
            {
                GameEntities ent = new GameEntities();
                Kingdom k = ent.Kingdoms.Where(x => x.Id == kingdom.Id).FirstOrDefault();
                k.Name = kingdom.Name;
                k.Place = kingdom.Place;
                k.Population = kingdom.Population;

                ent.Entry(ent.Kingdoms.Where(x => x.Id == k.Id).First()).CurrentValues.SetValues(k);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(kingdom);
            }
        }


        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public ActionResult Details(int id)
        {
            GameEntities ent = new GameEntities();
            KingdomModel model = ent.Kingdoms.Where(x => x.Id == id).FirstOrDefault().ToKingdomViewModel();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            GameEntities ent = new GameEntities();

            List<Army> army = ent.Armies.Where(x=>x.KingdomId==id).ToList();

            foreach (Army a in army)
                ent.Armies.Remove(a);


            Kingdom kingdom = ent.Kingdoms.Where(x => x.Id == id).First();
            ent.Kingdoms.Remove(kingdom);
            ent.SaveChanges();    
            return RedirectToAction("Index");
        }



    }
}