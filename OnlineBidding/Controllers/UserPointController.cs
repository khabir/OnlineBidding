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
    public class UserPointController : Controller
    {
        private OnlineBiddingContext db = new OnlineBiddingContext();

        // GET: /UserPoint/
        public ActionResult Index()
        {
            return View(db.UserPoints.ToList());
        }

        // GET: /UserPoint/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPoint userpoint = db.UserPoints.Find(id);
            if (userpoint == null)
            {
                return HttpNotFound();
            }
            return View(userpoint);
        }

        // GET: /UserPoint/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserPoint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TeamID,TotalPoint,NoOfBid,AddedPoint,DeductedPoint,Comments")] UserPoint userpoint)
        {
            if (ModelState.IsValid)
            {
                db.UserPoints.Add(userpoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userpoint);
        }

        // GET: /UserPoint/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPoint userpoint = db.UserPoints.Find(id);
            if (userpoint == null)
            {
                return HttpNotFound();
            }
            return View(userpoint);
        }

        // POST: /UserPoint/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TeamID,TotalPoint,NoOfBid,AddedPoint,DeductedPoint,Comments")] UserPoint userpoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userpoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userpoint);
        }

        // GET: /UserPoint/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPoint userpoint = db.UserPoints.Find(id);
            if (userpoint == null)
            {
                return HttpNotFound();
            }
            return View(userpoint);
        }

        // POST: /UserPoint/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserPoint userpoint = db.UserPoints.Find(id);
            db.UserPoints.Remove(userpoint);
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
