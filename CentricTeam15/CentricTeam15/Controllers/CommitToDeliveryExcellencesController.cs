using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentricTeam15.DAL;
using CentricTeam15.Models;

namespace CentricTeam15.Controllers
{
    public class CommitToDeliveryExcellencesController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: CommitToDeliveryExcellences
        public ActionResult Index()
        {
            return View(db.CommitToDeliveryExcellences.ToList());
        }

        // GET: CommitToDeliveryExcellences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitToDeliveryExcellence commitToDeliveryExcellence = db.CommitToDeliveryExcellences.Find(id);
            if (commitToDeliveryExcellence == null)
            {
                return HttpNotFound();
            }
            return View(commitToDeliveryExcellence);
        }

        // GET: CommitToDeliveryExcellences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommitToDeliveryExcellences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "deID,fistName,lastName")] CommitToDeliveryExcellence commitToDeliveryExcellence)
        {
            if (ModelState.IsValid)
            {
                db.CommitToDeliveryExcellences.Add(commitToDeliveryExcellence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commitToDeliveryExcellence);
        }

        // GET: CommitToDeliveryExcellences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitToDeliveryExcellence commitToDeliveryExcellence = db.CommitToDeliveryExcellences.Find(id);
            if (commitToDeliveryExcellence == null)
            {
                return HttpNotFound();
            }
            return View(commitToDeliveryExcellence);
        }

        // POST: CommitToDeliveryExcellences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "deID,fistName,lastName")] CommitToDeliveryExcellence commitToDeliveryExcellence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commitToDeliveryExcellence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commitToDeliveryExcellence);
        }

        // GET: CommitToDeliveryExcellences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitToDeliveryExcellence commitToDeliveryExcellence = db.CommitToDeliveryExcellences.Find(id);
            if (commitToDeliveryExcellence == null)
            {
                return HttpNotFound();
            }
            return View(commitToDeliveryExcellence);
        }

        // POST: CommitToDeliveryExcellences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommitToDeliveryExcellence commitToDeliveryExcellence = db.CommitToDeliveryExcellences.Find(id);
            db.CommitToDeliveryExcellences.Remove(commitToDeliveryExcellence);
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
