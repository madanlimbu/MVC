using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Research.Models;

namespace Research.Controllers
{
    public class EventsController : Controller
    {
        private UsersDB db = new UsersDB();

        // GET: Events
        public ActionResult Index()
        {

      //  Works    // db.Events.Add(new Event() { EventName = "ffs" });
            // db.SaveChanges();
         //   Event @event = db.Events.Find(1);
         //   if (@event == null)
         //  {
         //       return HttpNotFound();
         //   }
            //  Works   //   @event.Users.Add(new User() { Name = "Hello", Email = "Parapomo" });
        //Works    User usr = db.Users.Find(1);
          //WORKS ABOVED  @event.Users.Add(usr);
           // db.SaveChanges();
     // Nope  //    db.Events.Find(1).Users.Add(db.Users.Find(1));
    // NOpe  //     db.Events.ElementAt(0).Users.Add(db.Users.ElementAt(0));
            return View(db.Events.ToList());
        }

    /*    public ActionResult AddUserToEvent(int? id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return View("Error");
            }
            User usr = db.Users.Find()
            return View("Details/" + id);
        }
       */
        [HttpPost]
        public ActionResult AddUserEvent(int eventID, int userName)
        {
            Event @event = db.Events.Find(eventID);
            if (@event == null)
            {
                return View("Error");
            }
           
            User usr = db.Users.Find(userName);
            if (usr == null)
            {
                return View("Error");
            }
         
                @event.Users.Add(usr);
                db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddUserToEventPage(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        public ActionResult RedirectDetail(int? id)
        {
            return RedirectToAction("Details", "Users", new { id = id });
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName")] Event @event)
        {
            if (ModelState.IsValid)
            {
                
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        // GET: Events/Edit/5
        public ActionResult UsersInEvent(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = db.Events.Find(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            if(@event.Users.Any())
            {
                return View(@event.Users.ToList());

            }else
            {
                return View("Error");
            }
            
        }


        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult DeleteUserInEvent(int? id2, int? id3)
        {
            if (id3 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id3);
            if (@event == null)
            {
                return View("Error");
            }
            User usr = db.Users.Find(id2);
            @event.Users.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
