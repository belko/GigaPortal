using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigaPortalData.Models.Collections;
using GigaPortalData.Models;
using GigaPortalData.Interfaces;
using GigaPortal.Models;
using System.Web.Routing;

namespace GigaPortal.Controllers
{
    public class ContentsController : Controller
    {
        private PortalDataContext db = new PortalDataContext();

        //
        // GET: /Content/

        public ActionResult Index()
        {
            int curWebId = this.CurrentWeb().Id;
            var newsescollections = db.NewsesCollections.Where(n => n.CurrentWebId == curWebId);
            var pagescollections = db.PagesCollections.Where(g => g.CurrentWebId==curWebId);
            var subWebs = db.Webs.Where(w => w.ParentWebId == curWebId);
            RouteValueDictionary rv = new RouteValueDictionary() { };
            
            List<ListGPObjectsModel> collections = new List<ListGPObjectsModel>(){
            
                new ListGPObjectsModel() { Title = "Страницы", Items = newsescollections.ToList<IGPObject>(), ActionName="Details",ControllerName="Contents" },
                new ListGPObjectsModel() { Title = "Сайты", Items = subWebs.ToList<IGPObject>(), ActionName = "Details", ControllerName = "Contents" }
                };
            
            ViewBag.NewsesCollections = newsescollections.ToList<IGPObject>();
            ViewBag.PagesCollections = pagescollections.ToList<IGPObject>();
            ViewBag.SubWebs = subWebs.ToList<IGPObject>();
            return View(pagescollections.ToList());
        }

        //
        // GET: /Content/Details/5

        public ActionResult Details(int id = 0)
        {
            GPPagesCollection gppagescollection = db.PagesCollections.Find(id);
            if (gppagescollection == null)
            {
                return HttpNotFound();
            }
            return View(gppagescollection);
        }

        //
        // GET: /Content/Create

        public ActionResult Create()
        {
            ViewBag.CurrentWebId = new SelectList(db.Webs, "Id", "Url");
            return View();
        }

        //
        // POST: /Content/Create

        [HttpPost]
        public ActionResult Create(GPPagesCollection gppagescollection)
        {
            if (ModelState.IsValid)
            {
                db.PagesCollections.Add(gppagescollection);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = gppagescollection.Id });
            }

            ViewBag.CurrentWebId = new SelectList(db.Webs, "Id", "Url", gppagescollection.CurrentWebId);
            return View(gppagescollection);
        }

        // GET: /Content/Create

        public ActionResult CreateNewses()
        {
            ViewBag.CurrentWebId = new SelectList(db.Webs, "Id", "Url");
            return View();
        }

        //
        // POST: /Content/Create

        [HttpPost]
        public ActionResult CreateNewses(GPNewsCollection gpnewscollection)
        {
            if (ModelState.IsValid)
            {
                db.NewsesCollections.Add(gpnewscollection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentWebId = new SelectList(db.Webs, "Id", "Url", gpnewscollection.CurrentWebId);
            return View(gpnewscollection);
        }

        //
        // GET: /Content/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GPPagesCollection gppagescollection = db.PagesCollections.Find(id);
            if (gppagescollection == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentWebId = new SelectList(db.Webs, "Id", "Url", gppagescollection.CurrentWebId);
            return View(gppagescollection);
        }

        //
        // POST: /Content/Edit/5

        [HttpPost]
        public ActionResult Edit(GPPagesCollection gppagescollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gppagescollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentWebId = new SelectList(db.Webs, "Id", "Url", gppagescollection.CurrentWebId);
            return View(gppagescollection);
        }

        //
        // GET: /Content/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GPPagesCollection gppagescollection = db.PagesCollections.Find(id);
            if (gppagescollection == null)
            {
                return HttpNotFound();
            }
            return View(gppagescollection);
        }

        //
        // POST: /Content/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GPPagesCollection gppagescollection = db.PagesCollections.Find(id);
            db.PagesCollections.Remove(gppagescollection);
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