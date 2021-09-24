using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTViDuMVCGiaiPTBac1.Models;

namespace BTViDuMVCGiaiPTBac1.Controllers
{
    public class PersonController : Controller
    {
        LTQLDbContext db = new LTQLDbContext();
        AutoGenerateKey auKey = new AutoGenerateKey();
        // GET: Person
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        public ActionResult Create()
        {
            string NewID = "";
            var ps = db.Persons.ToList().OrderByDescending(c => c.PersonID);
            var countPS = db.Persons.Count();

            if (countPS == 0)
            {
                NewID = "PS001";
            }
            else
            {
                NewID = auKey.GenerateKey(ps.FirstOrDefault().PersonID);
            } 
            ViewBag.newPerID = NewID;
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person ps)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(ps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(string id)
        {

            var ps = db.Persons.Select(p => p).Where(p => p.PersonID == id).FirstOrDefault();
            return View(ps);

        }
        [HttpPost]
        public ActionResult Edit(Person ps)
        {
            try
            {
                var pse = db.Persons.Select(p => p).Where(p => p.PersonID == ps.PersonID).FirstOrDefault();
                pse.Adress = ps.Adress;
                pse.PersonName = ps.PersonName;   

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var ps = db.Persons.Where(p => p.PersonID == id).FirstOrDefault();
            return View(ps);
        }

        [HttpPost]
        public ActionResult Delete(String id,FormCollection collection)
        {
                using(LTQLDbContext db = new LTQLDbContext())
                {
                    var ps = db.Persons.Where(p => p.PersonID == id).FirstOrDefault();
              
                    db.Persons.Remove(ps);
                    db.SaveChanges();
                 }
                 return RedirectToAction("Index");
        }

    }

}
