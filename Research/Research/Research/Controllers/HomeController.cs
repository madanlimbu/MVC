using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Research.Models;
using System.Net;

namespace Research.Controllers
{
    public class HomeController : Controller
    {
        UsersDB db = new UsersDB();

        public ActionResult Index()
        {
            ViewBag.Message = "This is Home Page.";
            return View();
        }

        public ActionResult Events()
        {
            return View(db.Events.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return View("Error");
            }
            return View(@event);
        }

        public ActionResult Announcements()
        {
               if(db.Announcements.Any())
            {
                return View(db.Announcements.ToList());
            }else
            {
                return View("Error");
            }
            
        }

        public ActionResult Chair()
        {
            return View(db.LinksToWebsite.ToList());

        }


        public ActionResult ChairLink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return Redirect(db.LinksToWebsite.Find(id).ChairWebsite); 

        }
        public ActionResult CoChairLink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return Redirect(db.LinksToWebsite.Find(id).CoChairWebsite);

        }

        public ActionResult About()
        {
            ViewBag.Message = db.About.ToList().LastOrDefault().Detail;
            return View();
        }

       
    }
}