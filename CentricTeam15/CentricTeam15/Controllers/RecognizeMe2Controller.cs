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
    public class RecognizeMe2Controller : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: RecognizeMe2
        public ActionResult Index()
        {
            return View(db.RecognizeMes.ToList());
        }

        // GET: RecognizeMe2/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognizeMe recognizeMe = db.RecognizeMes.Find(id);
            if (recognizeMe == null)
            {
                return HttpNotFound();
            }
            return View(recognizeMe);
        }

        // GET: RecognizeMe2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecognizeMe2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,bussinessUnit,description,coreValue")] RecognizeMe recognizeMe)
        {
            if (ModelState.IsValid)
            {
                recognizeMe.ID = Guid.NewGuid();
                db.RecognizeMes.Add(recognizeMe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recognizeMe);
        }

        // GET: RecognizeMe2/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognizeMe recognizeMe = db.RecognizeMes.Find(id);
            if (recognizeMe == null)
            {
                return HttpNotFound();
            }
            return View(recognizeMe);
        }

        // POST: RecognizeMe2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,bussinessUnit,description,coreValue")] RecognizeMe recognizeMe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognizeMe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognizeMe);
        }

        // GET: RecognizeMe2/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognizeMe recognizeMe = db.RecognizeMes.Find(id);
            if (recognizeMe == null)
            {
                return HttpNotFound();
            }
            return View(recognizeMe);
        }

        // POST: RecognizeMe2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RecognizeMe recognizeMe = db.RecognizeMes.Find(id);
            db.RecognizeMes.Remove(recognizeMe);
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
