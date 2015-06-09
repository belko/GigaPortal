using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigaPortalData.Models;


namespace GigaPortal.Controllers
{
    public class WebsController : Controller
    {
        private PortalDataContext db = new PortalDataContext();

        //
        // GET: /Webs/

        public ActionResult Index()
        {
            var webs = db.Webs.Include(g => g.ParentWeb);
            return View(webs.ToList());

            //var sid = GPUser.Instance.SID;
            
        }

        //
        // GET: /Webs/Details/5

        public ActionResult Details(int id = 0)
        {
            GPWeb gpweb = db.Webs.Find(id);
            if (gpweb == null)
            {
                return HttpNotFound();
            }
            return View(gpweb);
        }

        //
        // GET: /Webs/Create

        public ActionResult Create()
        {
            ViewBag.ParentWebId = new SelectList(db.Webs, "Id", "Url");
            return View();
        }

        //
        // POST: /Webs/Create

        [HttpPost]
        public ActionResult Create(GPWeb gpweb)
        {
            if (ModelState.IsValid)
            {
                db.Webs.Add(gpweb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentWebId = new SelectList(db.Webs, "Id", "Url", gpweb.ParentWebId);
            return View(gpweb);
        }

        //
        // GET: /Webs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GPWeb gpweb = db.Webs.Find(id);
            if (gpweb == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentWebId = new SelectList(db.Webs, "Id", "Url", gpweb.ParentWebId);
            return View(gpweb);
        }

        //
        // POST: /Webs/Edit/5

        [HttpPost]
        public ActionResult Edit(GPWeb gpweb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gpweb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentWebId = new SelectList(db.Webs, "Id", "Url", gpweb.ParentWebId);
            return View(gpweb);
        }

        //
        // GET: /Webs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GPWeb gpweb = db.Webs.Find(id);
            if (gpweb == null)
            {
                return HttpNotFound();
            }
            return View(gpweb);
        }

        //
        // POST: /Webs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GPWeb gpweb = db.Webs.Find(id);
            db.Webs.Remove(gpweb);
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