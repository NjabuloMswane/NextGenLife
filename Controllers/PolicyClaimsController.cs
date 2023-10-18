using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NextGenLife.Models;

namespace NextGenLife.Controllers
{
    public class PolicyClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Approve(int? id)
        {
            ApprovedPolicyClaim approvedPolicyClaim = new ApprovedPolicyClaim();
            PolicyClaim policyClaim  = db.PolicyClaims.Where(p => p.PolicyClaimPK == id).FirstOrDefault();
          
           
                 var userId = User;

                var userName = User.Identity.GetUserName();

                approvedPolicyClaim.PolicyUserName = policyClaim.PolicyUserName;
                approvedPolicyClaim.PolicyReason = policyClaim.PolicyReason;
                approvedPolicyClaim.PolicyClaimStatus = "Approved";
                approvedPolicyClaim.PolicyStatus = policyClaim.PolicyStatus;
                approvedPolicyClaim.PolicyClaimDate = policyClaim.PolicyClaimDate;

                approvedPolicyClaim.PolicyName = policyClaim.PolicyName;
                approvedPolicyClaim.PolicyMonthlyFee = policyClaim.PolicyMonthlyFee;
                approvedPolicyClaim.PolicyPlanDescription = policyClaim.PolicyPlanDescription;
                approvedPolicyClaim.PolicyPayoutAmount = policyClaim.PolicyPayoutAmount;




                db.approvedPolicyClaims.Add(approvedPolicyClaim);
                db.SaveChanges();

                db.PolicyClaims.Remove(policyClaim);
                db.SaveChanges();


                return RedirectToAction("DashboardClaim", "Home");
        

        }

        public ActionResult Reject(int? id)
        {
            ApprovedPolicyClaim approvedPolicyClaim = new ApprovedPolicyClaim();
            PolicyClaim policyClaim = db.PolicyClaims.Where(p => p.PolicyClaimPK == id).FirstOrDefault();
  
         

                var userId = User;

                var userName = User.Identity.GetUserName();

                approvedPolicyClaim.PolicyUserName = policyClaim.PolicyUserName;
                approvedPolicyClaim.PolicyReason = policyClaim.PolicyReason;
                approvedPolicyClaim.PolicyClaimStatus = "Rejected";
                approvedPolicyClaim.PolicyStatus = policyClaim.PolicyStatus;
                approvedPolicyClaim.PolicyClaimDate = policyClaim.PolicyClaimDate;
                approvedPolicyClaim.PolicyName = policyClaim.PolicyName;
                approvedPolicyClaim.PolicyMonthlyFee = policyClaim.PolicyMonthlyFee;
                approvedPolicyClaim.PolicyPlanDescription = policyClaim.PolicyPlanDescription;
                approvedPolicyClaim.PolicyPayoutAmount = policyClaim.PolicyPayoutAmount;




            db.approvedPolicyClaims.Add(approvedPolicyClaim);
                db.SaveChanges();

                db.PolicyClaims.Remove(policyClaim);
                db.SaveChanges();


                return RedirectToAction("DashboardClaim", "Home");
           

        }
        // GET: PolicyClaims
        public ActionResult Index()
        {
            return View(db.PolicyClaims.ToList());
        }
        // GET: PolicyClaims
        public ActionResult Index1()
        {
            return View(db.PolicyClaims.ToList());
        }

        // GET: PolicyClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyClaim policyClaim = db.PolicyClaims.Find(id);
            if (policyClaim == null)
            {
                return HttpNotFound();
            }
            return View(policyClaim);
        }

        // GET: PolicyClaims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolicyClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyClaimPK,PolicyUserName,PolicyReason,PolicyStatus,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount")] PolicyClaim policyClaim)
        {
            if (ModelState.IsValid)
            {
                db.PolicyClaims.Add(policyClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policyClaim);
        }

        // GET: PolicyClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyClaim policyClaim = db.PolicyClaims.Find(id);
            if (policyClaim == null)
            {
                return HttpNotFound();
            }
            return View(policyClaim);
        }

        // POST: PolicyClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyClaimPK,PolicyUserName,PolicyReason,PolicyStatus,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount")] PolicyClaim policyClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policyClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policyClaim);
        }

        // GET: PolicyClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyClaim policyClaim = db.PolicyClaims.Find(id);
            if (policyClaim == null)
            {
                return HttpNotFound();
            }
            return View(policyClaim);
        }

        // POST: PolicyClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PolicyClaim policyClaim = db.PolicyClaims.Find(id);
            db.PolicyClaims.Remove(policyClaim);
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
