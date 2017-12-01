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
    public class RecognizeMesController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: RecognizeMes
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var recognizeMes = db.RecognizeMes.Include(r => r.PersonGettingAward);
                return View(recognizeMes.ToList());
            }

            else
            {
                return View("NotAuthorizedRecognizeMes");
            }
        }

        // GET: RecognizeMes/Details/5
        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognizeMe recognizeMe = db.RecognizeMes.Find(ID);
            if (recognizeMe == null)
            {
                return HttpNotFound();
            }
            return View(recognizeMe);
        }

        // GET: RecognizeMes/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.AccountDetails, "ID", "fullName");
            return View();
        }

        // POST: RecognizeMes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,recognitionID,bussinessUnit,description,CoreValue,CurrentDateTime")] RecognizeMe recognizeMe)
        {
            if (ModelState.IsValid)
            {
                recognizeMe.CurrentDateTime = DateTime.Now;
                db.RecognizeMes.Add(recognizeMe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.AccountDetails, "ID", "fullName", recognizeMe.ID);
            return View(recognizeMe);
        }

        // GET: RecognizeMes/Edit/5
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognizeMe recognizeMe = db.RecognizeMes.Find(ID);
            if (recognizeMe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.AccountDetails, "ID", "fullName", recognizeMe.ID);
            return View(recognizeMe);
        }

        // POST: RecognizeMes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,bussinessUnit,description,CoreValue,CurrentDateTime")] RecognizeMe recognizeMe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognizeMe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.AccountDetails, "ID", "fullName", recognizeMe.ID);
            return View(recognizeMe);
        }

        // GET: RecognizeMes/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognizeMe recognizeMe = db.RecognizeMes.Find(ID);
            if (recognizeMe == null)
            {
                return HttpNotFound();
            }
            return View(recognizeMe);
        }

        // POST: RecognizeMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            RecognizeMe recognizeMe = db.RecognizeMes.Find(ID);
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
