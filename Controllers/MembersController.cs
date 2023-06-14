using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlirezaAbasi.Models;

namespace AlirezaAbasi.Controllers
{
    public class MembersController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Members
        public ActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var members = db.Members.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m => m.FullName.Contains(searchString)).ToList();
                return View(members);
            }

            var memberList = db.Members.ToList();
            return View(memberList);

        }

        // GET: Members/Details/5
        public ActionResult ShowCard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegisterCode,FullName,BirthDate,Address")] Members members)
        {
            if (ModelState.IsValid)
            {
                members.RegisterDate = DateTime.Now;
                members.ExpireDate = DateTime.Now.AddDays(60);
                db.Members.Add(members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(members);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegisterCode,FullName,RegisterDate,ExpireDate,BirthDate,Address")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(members);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult Search()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Search(string registerCode)
        //{
            
        //    return View();
        //}

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
