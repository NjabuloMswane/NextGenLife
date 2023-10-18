using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NextGenLife.Models;

namespace NextGenLife.Controllers
{
    public class ApprovedPolicyClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApprovedPolicyClaims
        public ActionResult Index()
        {
            return View(db.approvedPolicyClaims.ToList());
        }

        // GET: ApprovedPolicyClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicyClaim approvedPolicyClaim = db.approvedPolicyClaims.Find(id);
            if (approvedPolicyClaim == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicyClaim);
        }

        // GET: ApprovedPolicyClaims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedPolicyClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApprovedPolicyClaimPK,PolicyUserName,PolicyReason,PolicyStatus,PolicyClaimDate,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount")] ApprovedPolicyClaim approvedPolicyClaim)
        {
            if (ModelState.IsValid)
            {
                db.approvedPolicyClaims.Add(approvedPolicyClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(approvedPolicyClaim);
        }

        // GET: ApprovedPolicyClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicyClaim approvedPolicyClaim = db.approvedPolicyClaims.Find(id);
            if (approvedPolicyClaim == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicyClaim);
        }

        // POST: ApprovedPolicyClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApprovedPolicyClaimPK,PolicyUserName,PolicyReason,PolicyStatus,PolicyClaimDate,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount")] ApprovedPolicyClaim approvedPolicyClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvedPolicyClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approvedPolicyClaim);
        }

        // GET: ApprovedPolicyClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicyClaim approvedPolicyClaim = db.approvedPolicyClaims.Find(id);
            if (approvedPolicyClaim == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicyClaim);
        }

        // POST: ApprovedPolicyClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApprovedPolicyClaim approvedPolicyClaim = db.approvedPolicyClaims.Find(id);
            db.approvedPolicyClaims.Remove(approvedPolicyClaim);
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
