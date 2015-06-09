using GigaPortal.Models;
using GigaPortalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GigaPortal.Controllers
{
    public class HomeController : Controller
    {
        private PortalDataContext db = new PortalDataContext();
        public ActionResult Index()
        {
            GPWeb web = this.CurrentWeb();
            ViewBag.Message = "Сейчас вы на сайте '"+web.Title+"';";
            
           
            
            ViewBag.Department = web.Id;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LeftMenu() 
        {
            int webId = this.CurrentWeb().Id;
            var pares = db.Webs.Where(w => w.ParentWebId == webId).Select(w => new { title = w.Title, url = w.Url }).ToList();
            List<NavLink> links = new List<NavLink>();
            pares.ForEach(p => links.Add(new NavLink()
            {
                Text = p.title,
                RouteValues = new RouteValueDictionary(
                    new { controller = "Home", action = "index", depname = p.url })
            }));
            
            return PartialView(links);
        }
    }
}
