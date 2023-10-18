using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using NextGenLife.Models;

namespace NextGenLife.Controllers
{
    public class PolicyPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

         public ActionResult ThankYouCreate()
        {
            return View();
        }
        public ActionResult ThankYou()
        {
            return View();
        }
        // GET: PolicyPlans
        public ActionResult Index()
        {
            var policyPlans = db.PolicyPlans.Include(p => p.Category);
            return View(policyPlans.ToList());
        }

        // GET: PolicyPlans
        public ActionResult PolicyList()
        {
            var policyPlans = db.PolicyPlans.Include(p => p.Category);
            return View(policyPlans.ToList());
        }


        // GET: PolicyPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyPlan policyPlan = db.PolicyPlans.Find(id);
            if (policyPlan == null)
            {
                return HttpNotFound();
            }
            return View(policyPlan);
        }

        // GET: PolicyPlans/Create
        public ActionResult Create()
        {
            ViewBag.Campaign_ID = new SelectList(db.Categories, "Campaign_ID", "Campaign_Name");
            return View();
        }

        // POST: PolicyPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyPlanPk,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Campaign_ID")] PolicyPlan policyPlan)
        {
            if (ModelState.IsValid)
            {
                db.PolicyPlans.Add(policyPlan);
                db.SaveChanges();
                return RedirectToAction("PolicyList");
            }

            ViewBag.Campaign_ID = new SelectList(db.Categories, "Campaign_ID", "Campaign_Name", policyPlan.Campaign_ID);
            return View(policyPlan);
        }

        // GET: PolicyPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyPlan policyPlan = db.PolicyPlans.Find(id);
            if (policyPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Campaign_ID = new SelectList(db.Categories, "Campaign_ID", "Campaign_Name", policyPlan.Campaign_ID);
            return View(policyPlan);
        }

        // POST: PolicyPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyPlanPk,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Campaign_ID")] PolicyPlan policyPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policyPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Campaign_ID = new SelectList(db.Categories, "Campaign_ID", "Campaign_Name", policyPlan.Campaign_ID);
            return View(policyPlan);
        }


        
        // GET: PolicyPlans/Edit/5
        public ActionResult PolicyAppliction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyPlan policyPlan = db.PolicyPlans.Find(id);
            if (policyPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Campaign_ID = new SelectList(db.Categories, "Campaign_ID", "Campaign_Name", policyPlan.Campaign_ID);
            return View(policyPlan);
        }

        // POST: PolicyPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PolicyAppliction([Bind(Include = "PolicyPlanPk,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Campaign_ID")] PolicyPlan policyPlan)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.GetUserName();

                PolicyAppliction policyAppliction = new PolicyAppliction();
                //policyAppliction.FirstName = UserProfile.LastName;
                //students = students.Where(s => s.Campaign_Name.Contains(searchString));
                policyAppliction.FirstName = userName;
                policyAppliction.LastName = userName;
                policyAppliction.gender = userName;
                policyAppliction.PolicyApplictionIdNumber = userName;
                policyAppliction.PolicyApplictionEmail = userName;

                policyAppliction.PolicyApplictionCellNumber = userName;
                policyAppliction.PolicyApplictionAlternativeNumber = userName;
                policyAppliction.PolicyName = policyPlan.PolicyName;
                policyAppliction.PolicyMonthlyFee = policyPlan.PolicyMonthlyFee;
                policyAppliction.PolicyPlanDescription = policyPlan.PolicyPlanDescription;
                policyAppliction.PolicyPayoutAmount = policyPlan.PolicyPayoutAmount;
                policyAppliction.Application_Date = "Today";
                policyAppliction.Application_Status = "Waiting";
                policyAppliction.ApplicationPaymentAmount = 0;
                policyAppliction.CardName = "";
                policyAppliction.CardNumber = "";
                policyAppliction.CVV = "";
                policyAppliction.ExpirationDate = "";
                policyAppliction.Paylocation = "Waiting";

                db.PolicyApplictions.Add(policyAppliction);
                db.SaveChanges();

                if(userName=="")
                {
                    return RedirectToAction("ThankYouCreate");
                }

                db.Entry(policyPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThankYou");
            }
            ViewBag.Campaign_ID = new SelectList(db.Categories, "Campaign_ID", "Campaign_Name", policyPlan.Campaign_ID);
            return View(policyPlan);
        }

        public IQueryable<UserProfile> FindByParentId()
        {
            var userName = User.Identity.GetUserName();
            //model.UserProfile = (from ac in ctx.UserProfiles
            //                      where post.UserProfileEmail == userName
            //                             select new UserProfile
            //                             {
            //                                 Blah = ac.Blah
            //                             }).ToList();





            return from post in db.UserProfiles
                   where post.UserProfileEmail == userName
            select new Models.UserProfile
            {
                FirstName = post.FirstName, 
                LastName = post.LastName,
                UserProfileIdNumber = post.UserProfileIdNumber,
                UserProfileEmail = userName,
                UserProfileAddress = post.UserProfileAddress,
                UserProfileAlternativeNumber = post.UserProfileAlternativeNumber,
                UserProfileCellNumber   = post.UserProfileCellNumber,
                gender = post.gender

            };
        }
        // GET: PolicyPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyPlan policyPlan = db.PolicyPlans.Find(id);
            if (policyPlan == null)
            {
                return HttpNotFound();
            }
            return View(policyPlan);
        }

        // POST: PolicyPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PolicyPlan policyPlan = db.PolicyPlans.Find(id);
            db.PolicyPlans.Remove(policyPlan);
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
