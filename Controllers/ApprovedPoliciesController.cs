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
    public class ApprovedPoliciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Thank()
        {
            return View();
        }

        // GET: ApprovedPolicies
        public ActionResult Index()
        {
            return View(db.approvedPolicies.ToList());
        }
        public ActionResult PaymentMethod()
        {
            var userName = User.Identity.GetUserName();
            return View(db.approvedPolicies.Where(x => x.PolicyApplictionEmail == userName).ToList());
        }
        public ActionResult ApprovedPolicy()
        {
            var userName = User.Identity.GetUserName();
            return View(db.approvedPolicies.Where(x => x.PolicyApplictionEmail == userName && x.Application_Status== "Approved").ToList());
        }

        public ActionResult ApprovedPolicyDetails()
        {
            var userName = User.Identity.GetUserName();
            return View(db.approvedPolicies.Where(x => x.PolicyApplictionEmail == userName && x.Application_Status == "Approved").ToList());
        }

        // GET: ApprovedPolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }

        // GET: ApprovedPolicies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                db.approvedPolicies.Add(approvedPolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(approvedPolicy);
        }

        // GET: ApprovedPolicies/Edit/5
        public ActionResult PayWithCash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }


        // POST: ApprovedPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PayWithCash([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvedPolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Thank");
            }
            return View(approvedPolicy);
        }



        // GET: ApprovedPolicies/Edit/5
        public ActionResult ClaimApplication(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }


        // POST: ApprovedPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClaimApplication([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                PolicyClaim policyClaim = new PolicyClaim();
                var userName = User.Identity.GetUserName();
           
                policyClaim.PolicyUserName = userName;
                policyClaim.PolicyReason = approvedPolicy.gender;
                policyClaim.PolicyStatus = approvedPolicy.Application_Status;
                policyClaim.PolicyClaimDate = DateTime.Now;
                policyClaim.PolicyName = approvedPolicy.PolicyName;
                policyClaim.PolicyMonthlyFee = approvedPolicy.PolicyMonthlyFee;
                policyClaim.PolicyPlanDescription = approvedPolicy.PolicyPlanDescription;
                policyClaim.PolicyPayoutAmount = approvedPolicy.PolicyPayoutAmount;




                db.PolicyClaims.Add(policyClaim);
                db.SaveChanges();
                //db.Entry(approvedPolicy).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Profile", "UserProfiles");

                //return RedirectToAction("Index");
            }
            return View(approvedPolicy);
        }

        // GET: ApprovedPolicies/Edit/5
        public ActionResult PayWithCard(int? id)
        
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }


        // POST: ApprovedPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PayWithCard([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvedPolicy).State = EntityState.Modified;
                db.SaveChanges();

                //return RedirectToAction("@{\r\n    ViewData[\"Title\"] = \"ThankYou\";\r\n    Layout = \"~/Views/Shared/_LayoutPage1.cshtml\";\r\n}\r\n\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title></title>\r\n    <link href='https://fonts.googleapis.com/css?family=Lato:300,400|Montserrat:700' rel='stylesheet' type='text/css'>\r\n    <link href=\"~/css/popup.css\" rel=\"stylesheet\" />\r\n\r\n    <link rel=\"stylesheet\" href=\"https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/default_thank_you.css\">\r\n    <script src=\"https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/jquery-1.9.1.min.js\"></script>\r\n    <script src=\"https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/html5shiv.js\"></script>\r\n</head>\r\n<body>\r\n    <header class=\"site-header\" id=\"header\">\r\n        <h1 class=\"site-header__title\" data-lead-id=\"site-header-title\">THANK YOU!</h1>\r\n    </header>\r\n\r\n    <div class=\"main-content\">\r\n        <i class=\"fa fa-check main-content__checkmark\" id=\"checkmark\"></i>\r\n        <p class=\"main-content__body\" data-lead-id=\"main-content-body\">Application submitted successfully Your email will be used to inform you of the application's outcome.</p>\r\n        \t<a class=\"button\" style=\"vertical-align:middle\" href=\"/Home/Index\">\r\n        <span>Back to Home Page </span>\r\n        </a>\r\n    </div>\r\n\r\n\r\n</body>\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            }
            return View(approvedPolicy);
        }


        [HttpPost]
        public ActionResult PayWithCard1([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvedPolicy).State = EntityState.Modified;
                db.SaveChanges();

                //return RedirectToAction("@{\r\n    ViewData[\"Title\"] = \"ThankYou\";\r\n    Layout = \"~/Views/Shared/_LayoutPage1.cshtml\";\r\n}\r\n\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title></title>\r\n    <link href='https://fonts.googleapis.com/css?family=Lato:300,400|Montserrat:700' rel='stylesheet' type='text/css'>\r\n    <link href=\"~/css/popup.css\" rel=\"stylesheet\" />\r\n\r\n    <link rel=\"stylesheet\" href=\"https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/default_thank_you.css\">\r\n    <script src=\"https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/jquery-1.9.1.min.js\"></script>\r\n    <script src=\"https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/html5shiv.js\"></script>\r\n</head>\r\n<body>\r\n    <header class=\"site-header\" id=\"header\">\r\n        <h1 class=\"site-header__title\" data-lead-id=\"site-header-title\">THANK YOU!</h1>\r\n    </header>\r\n\r\n    <div class=\"main-content\">\r\n        <i class=\"fa fa-check main-content__checkmark\" id=\"checkmark\"></i>\r\n        <p class=\"main-content__body\" data-lead-id=\"main-content-body\">Application submitted successfully Your email will be used to inform you of the application's outcome.</p>\r\n        \t<a class=\"button\" style=\"vertical-align:middle\" href=\"/Home/Index\">\r\n        <span>Back to Home Page </span>\r\n        </a>\r\n    </div>\r\n\r\n\r\n</body>\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            }
            return View(approvedPolicy);
        }


        // GET: ApprovedPolicies/Edit/5
        public ActionResult MakePolicyClaim(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }


        // POST: ApprovedPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePolicyClaim([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvedPolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approvedPolicy);
        }



        // GET: ApprovedPolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }

        // POST: ApprovedPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApprovedPolicyPk,FirstName,Paylocation,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyApplictionEmail,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] ApprovedPolicy approvedPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvedPolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approvedPolicy);
        }

        // GET: ApprovedPolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            if (approvedPolicy == null)
            {
                return HttpNotFound();
            }
            return View(approvedPolicy);
        }

        // POST: ApprovedPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApprovedPolicy approvedPolicy = db.approvedPolicies.Find(id);
            db.approvedPolicies.Remove(approvedPolicy);
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
