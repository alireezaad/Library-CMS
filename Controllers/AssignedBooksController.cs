using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using AlirezaAbasi.Models;

namespace AlirezaAbasi.Controllers
{
    public class AssignedBooksController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: AssignedBooks
        public ActionResult Index()
        {
            //var aBooks = db.AssignedBooks.ToList();
            var aBooks = db.AssignedBooks.Include(a => a.books).Include(a => a.members);

            return View(aBooks);
        }

        public ActionResult Assign()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign([Bind(Include = "Id,ReturnDate")] AssignedBooks assignedBooks,int registerCode, int bookCode)
        {
            if (ModelState.IsValid)
            {
                var member = db.Members.FirstOrDefault(t => t.RegisterCode == registerCode);
                var book = db.Books.FirstOrDefault(t => t.Code == bookCode);
                if (member == null)
                {
                    ModelState.AddModelError("RegisterCode", "Please inster a valid member code!");
                }
                if (book == null)
                {
                    ModelState.AddModelError("BookCode", "Please inster a valid Book code!");
                }
                assignedBooks.members = member;
                assignedBooks.StartDate = DateTime.Now;
                assignedBooks.books.Add(book);
                db.AssignedBooks.Add(assignedBooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignedBooks);
        }

        // GET: AssignedBooks/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AssignedBooks assignedBooks = db.AssignedBooks.Find(id);
        //    if (assignedBooks == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(assignedBooks);
        //}

        //// POST: AssignedBooks/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,StartDate,ReturnDate")] AssignedBooks assignedBooks)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(assignedBooks).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(assignedBooks);
        //}

        // GET: AssignedBooks/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AssignedBooks assignedBooks = db.AssignedBooks.Find(id);
        //    if (assignedBooks == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(assignedBooks);
        //}

        //// POST: AssignedBooks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AssignedBooks assignedBooks = db.AssignedBooks.Find(id);
        //    db.AssignedBooks.Remove(assignedBooks);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
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
