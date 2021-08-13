using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineBidding.Model;
using OnlineBidding.DAL;

namespace OnlineBidding.Controllers
{
    public class UserController : Controller
    {
        private OnlineBiddingContext db = new OnlineBiddingContext();

        // GET: /User/
        public ActionResult Index()
        {
            List<SelectListItem> teams = new List<SelectListItem>();
            
            //obj.Add(new SelectListItem { Text = "Solid State", Value = "1" });
            //obj.Add(new SelectListItem { Text = "Liquid State", Value = "2" });
            //obj.Add(new SelectListItem { Text = "Gas State", Value = "3" });

            db.Team.ForEachAsync(t => teams.Add(new SelectListItem() { Text = t.Name, Value = t.ID.ToString() }));

            ViewBag.Teams = (IEnumerable<SelectListItem>)teams;
            ViewData["Teams"] = (IEnumerable<SelectListItem>)teams;

            return View(db.User.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,UserName,Password,Email,Phone,DOB,Active,RoleID")] User user)
        {
            //ViewBag.Error = "Username is Already Exists.";
            //return RedirectToAction("Create", "User");

            if (ModelState.IsValid)
            {
                var currentUser = db.User.Where(u => u.UserName == user.UserName);
                if (currentUser != null && currentUser.Count() > 0)
                {
                    return Content("Username is Already Exists.");
                }
                db.User.Add(user);

                UserPoint point = new UserPoint()
                {
                    AddedPoint = 0,
                    Comments = "",
                    DeductedPoint = 0,
                    NoOfBid = 0,
                    TeamID = 0,
                    TotalPoint = 100
                };

                db.UserPoints.Add(point);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,UserName,Password,Email,Phone,DOB,Active,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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
