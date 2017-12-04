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

        //// POST: AccountDetails/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult Create([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo,userBiography")] AccountDetail userDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Guid memberID;
        //        Guid.TryParse(User.Identity.GetUserId(), out memberID);
        //        userDetails.ID = memberID;
                

        //        try
        //        {
        //            HttpPostedFileBase file = Request.Files["photo"]; //(A) – see notes below
        //                                                              //accountDetail.photo = Guid.NewGuid();
        //            if (file != null && file.FileName != null && file.FileName != "") //(B)
        //            {
        //                FileInfo fi = new FileInfo(file.FileName); //(C)
        //                if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png") //(D)
        //                {
        //                    TempData["Errormsg"] = "Image File Extension is not valid"; //(E)
        //                    return View(userDetails);
        //                }
        //                else
        //                {
        //                    userDetails.photo = userDetails.ID + fi.Extension; //(F)

        //                    file.SaveAs(Server.MapPath("~/_Images/" + userDetails.photo));  //(G)

        //                }
        //            }
        //            db.AccountDetails.Add(userDetails);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception)
        //        {
        //        return View("DuplicateUser");
        //        }
        //        }

        //    return View(userDetails);
        //}

        //New Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo,userBiography")] AccountDetail userData)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userData.ID = memberID;


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
                            return View(userData);
                        }
                        else
                        {
                            userData.photo = userData.ID + fi.Extension; //(F)

                            file.SaveAs(Server.MapPath("~/_Images/" + userData.photo));  //(G)

                        }
                    }
                    db.AccountDetails.Add(userData);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View("DuplicateUser");
                }
            }

            return View(userData);
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

        //// POST: AccountDetails/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult Edit([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo,userBiography")] AccountDetail userDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userDetails).State = EntityState.Modified;

        //        HttpPostedFileBase file = Request.Files["photo"];

        //        if (file != null && file.FileName != null && file.FileName != "")
        //        {
        //            FileInfo fi = new FileInfo(file.FileName);
        //            if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png")
        //            {
        //                TempData["Errormsg"] = "Image File Extension is not valid";
        //                return View(userDetails);
        //            }
        //            else
        //            {
        //                // there is a new image, so delete the old one, if any, first
        //                AccountDetail photoOld = db.AccountDetails.Find(userDetails.photo);
        //                string photoName = photoOld.photo;
        //                string path = Server.MapPath("~/_Images/" + photoName);
        //                // there may not be a file, so use try/catch
        //                try
        //                {
        //                    if (System.IO.File.Exists(path))
        //                    {
        //                        System.IO.File.Delete(path);
        //                    }
        //                    else
        //                    {
        //                        // must already be deleted
        //                    }
        //                }
        //                catch (Exception Ex)
        //                {
        //                    // delete failed - probably not a real issue
        //                }
        //                // now upload the new image
        //                userDetails.photo = userDetails.ID + fi.Extension;

        //                file.SaveAs(Server.MapPath("~/_Images/" + userDetails.photo));

        //            }
        //        }

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userDetails);
        //}

        //new edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo,userBiography")] AccountDetail userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;

                HttpPostedFileBase file = Request.Files["photo"];

                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png")
                    {
                        TempData["Errormsg"] = "Image File Extension is not valid";
                        return View(userData);
                    }
                    else
                    {
                        // there is a new image, so delete the old one, if any, first
                        //   AccountDetail photoOld = db.AccountDetails.Find(userData.photo);
                        //  AccountDetail photoOld = db.AccountDetails.Find(userData.ID);
                        string photoName = userData.photo;
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
                        userData.photo = userData.ID + fi.Extension;

                        file.SaveAs(Server.MapPath("~/_Images/" + userData.photo));

                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userData);
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
                //return View(db.AccountDetails.ToList());
                return View("Dashboard");
            }

            else
            {
                return View("NotAuthorized");
            }
        }


        

    }



}


