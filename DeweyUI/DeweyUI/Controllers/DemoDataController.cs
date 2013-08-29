using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeweyUI.Models;

namespace DeweyUI.Controllers
{
    public class DemoDataController : Controller
    {
        private DemoDataDBContext db = new DemoDataDBContext();

        //
        // GET: /DemoData/

        public ActionResult Index()
        {
            return View(db.DemoData.ToList());
        }

        //
        // GET: /DemoData/Details/5

        public ActionResult Details(int id = 0)
        {
            DemoData demodata = db.DemoData.Find(id);
            if (demodata == null)
            {
                return HttpNotFound();
            }
            return View(demodata);
        }

        //
        // GET: /DemoData/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DemoData/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DemoData demodata)
        {
            if (ModelState.IsValid)
            {
                db.DemoData.Add(demodata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demodata);
        }

        //
        // GET: /DemoData/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DemoData demodata = db.DemoData.Find(id);
            if (demodata == null)
            {
                return HttpNotFound();
            }
            return View(demodata);
        }

        //
        // POST: /DemoData/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DemoData demodata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demodata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demodata);
        }

        //
        // GET: /DemoData/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DemoData demodata = db.DemoData.Find(id);
            if (demodata == null)
            {
                return HttpNotFound();
            }
            return View(demodata);
        }

        //
        // POST: /DemoData/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemoData demodata = db.DemoData.Find(id);
            db.DemoData.Remove(demodata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}