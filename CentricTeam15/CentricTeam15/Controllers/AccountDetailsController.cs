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
using Microsoft.AspNet.Identity;
using System.IO;

namespace CentricTeam15.Controllers
{
    public class AccountDetailsController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: AccountDetails
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
            return View(db.AccountDetails.ToList());
            }

            else
            {
                return View("NotAuthorized");
            }
        }

        // GET: AccountDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            return View(accountDetail);
        }

        // GET: AccountDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo,userBiography")] AccountDetail ID)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                ID.ID = memberID;
                

                try
                {
                    HttpPostedFileBase file = Request.Files["photo"]; //(A) – see notes below
                                                                      //accountDetail.photo = Guid.NewGuid();
                    if (file != null && file.FileName != null && file.FileName != "") //(B)
                    {
                        FileInfo fi = new FileInfo(file.FileName); //(C)
                        if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png") //(D)
                        {
                            TempData["Errormsg"] = "Image File Extension is not valid"; //(E)
                            return View(ID);
                        }
                        else
                        {
                            ID.photo = ID.ID + fi.Extension; //(F)

                            file.SaveAs(Server.MapPath("~/_Images/" + ID.photo));  //(G)

                        }
                    }
                    db.AccountDetails.Add(ID);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                return View("DuplicateUser");
                }
                }

            return View(ID);
        }

        // GET: AccountDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail user = db.AccountDetails.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);

            return View(user);
          

        }

        // POST: AccountDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo,userBiography")] AccountDetail ID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ID).State = EntityState.Modified;

                HttpPostedFileBase file = Request.Files["photo"];

                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png")
                    {
                        TempData["Errormsg"] = "Image File Extension is not valid";
                        return View(ID);
                    }
                    else
                    {
                        // there is a new image, so delete the old one, if any, first
                        AccountDetail photoOld = db.AccountDetails.Find(ID.photo);
                        string photoName = photoOld.photo;
                        string path = Server.MapPath("~/_Images/" + photoName);
                        // there may not be a file, so use try/catch
                        try
                        {
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                            else
                            {
                                // must already be deleted
                            }
                        }
                        catch (Exception Ex)
                        {
                            // delete failed - probably not a real issue
                        }
                        // now upload the new image
                        ID.photo = ID.ID + fi.Extension;

                        file.SaveAs(Server.MapPath("~/_Images/" + ID.photo));

                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ID);
        }

        // GET: AccountDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            return View(accountDetail);
        }

        // POST: AccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountDetail ID = db.AccountDetails.Find(id);

            string photoName = ID.photo; //(A)
            string path = Server.MapPath("~/_Images/" + photoName); //(B)
                                                                    // there may not be a file, so use try/catch
            try
            {
                if (System.IO.File.Exists(path)) //(C)
                {
                    System.IO.File.Delete(path); //(D)
                }
                else
                {
                    // must already be deleted (E)
                }
            }
            catch (Exception Ex)
            {
                // delete failed - probably not a real issue (F)
            }

            db.AccountDetails.Remove(ID);
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



        [Authorize]


        public ActionResult Dashboard()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = db.AccountDetails.Include(u => u.ID);

                //var accountDetail = db.AccountDetails.Include(d => d.ID);

                return View("Dashboard");
            }


            else
            {
                return View("NotAuthorized");
            }
        }


        // if (User.Identity.IsAuthenticated)
        //public ActionResult Dashboard(int? ID)
        //{
        //    if (ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccountDetail accountDetail = db.AccountDetails.Find(ID);
        //    if (accountDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accountDetail);
        //}



    }



}


