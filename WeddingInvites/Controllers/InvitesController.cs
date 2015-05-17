using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeddingInvites.Models;

namespace WeddingInvites.Controllers
{
    public class InvitesController : Controller
    {
        private InviteDBContext db = new InviteDBContext();

        // GET: Invites
        public ActionResult Index(string party, string searchString)
        {
            var PartyList = new List<string>();

            var PartyQry = from d in db.Invites
                           orderby d.Party
                           select d.Party;

            PartyList.AddRange(PartyQry.Distinct());
            ViewBag.party = new SelectList(PartyList);
            
            var invites = from i in db.Invites
                          select i;
            var inviteCount = 0;
            var headCount = 0;
            foreach (var invite_row in invites) {
                inviteCount++;
                if (invite_row.Invitees.HasValue)
                {
                    headCount += (int)invite_row.Invitees;
                }
            }

            ViewBag.inviteCount = inviteCount;
            ViewBag.headCount = headCount;

            if (!String.IsNullOrEmpty(searchString))
            {
                invites = invites.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(party))
            {
                invites = invites.Where(x => x.Party == party);
            }

            return View(invites);
        }

        // GET: Invites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = db.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // GET: Invites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,City,State,Zip,Party,Type,Invitees,InviteSent,Confirmed,AttendingCount,Notes")] Invite invite)
        {
            if (ModelState.IsValid)
            {
                db.Invites.Add(invite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invite);
        }

        // GET: Invites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = db.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // POST: Invites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,City,State,Zip,Party,Type,Invitees,InviteSent,Confirmed,AttendingCount,Notes")] Invite invite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invite);
        }

        // GET: Invites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = db.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // POST: Invites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invite invite = db.Invites.Find(id);
            db.Invites.Remove(invite);
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

        public void ExportToCSV()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();

            sw.WriteLine("\"Name\",\"Party\",\"Type\",\"Invitees\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (var inviteRow in db.Invites)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                                           inviteRow.Name,
                                           inviteRow.Party,
                                           inviteRow.Type,
                                           inviteRow.Invitees));
            }

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
