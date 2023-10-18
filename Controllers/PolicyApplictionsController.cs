using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NextGenLife.Models;

namespace NextGenLife.Controllers
{
    public class PolicyApplictionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PolicyApplictions
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();

            var students = from s in db.UserProfiles
                           where s.UserProfileEmail == userName
                           select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    students = students.Where(s => s.Campaign_Name.Contains(searchString));

            //    return View(students.ToList());

            //}
            //return View(campaign_Service.GetCampaign());




            return View(db.PolicyApplictions.ToList());

            //return View(db.UserProfiles.ToList());

          
        }


        public ActionResult Approve(int? id)
        {
            ApprovedPolicy approvedPolicy = new ApprovedPolicy();   
            PolicyAppliction policyAppliction = db.PolicyApplictions.Where(p => p.PolicyApplictionPk == id).FirstOrDefault();
            if (policyAppliction.Application_Status == "Approved" || policyAppliction.Application_Status == "Rejected")
            {
                TempData["AlertMessage"] = "The application has already been Rejected/Approved";
                return RedirectToAction("AdminPage");
            }
            else
            {
               

                //SendEmail em = new SendEmail();
                //em.TriggerStatusSendEmail(approvedLeave);
                var userId = User;

                var userName = User.Identity.GetUserName();

                approvedPolicy.FirstName = policyAppliction.FirstName;
                approvedPolicy.LastName = policyAppliction.LastName;
                approvedPolicy.gender = policyAppliction.gender;
                approvedPolicy.PolicyApplictionEmail = policyAppliction.gender;

                approvedPolicy.PolicyApplictionIdNumber = policyAppliction.PolicyApplictionIdNumber;
                approvedPolicy.PolicyApplictionCellNumber = policyAppliction.PolicyApplictionCellNumber;
                approvedPolicy.PolicyApplictionAlternativeNumber = policyAppliction.PolicyApplictionAlternativeNumber;
                approvedPolicy.PolicyName = policyAppliction.PolicyName;
                approvedPolicy.PolicyMonthlyFee = policyAppliction.PolicyMonthlyFee;
                approvedPolicy.PolicyPlanDescription = policyAppliction.PolicyPlanDescription;
                approvedPolicy.PolicyPayoutAmount = policyAppliction.PolicyPayoutAmount;
                approvedPolicy.Application_Date = "Today";
                approvedPolicy.Application_Status = "Approved";
                approvedPolicy.ApplicationPaymentAmount = 0;
                approvedPolicy.CardName = "";
                approvedPolicy.CardNumber = "";
                approvedPolicy.CVV = "";
                approvedPolicy.ExpirationDate = "";
                approvedPolicy.Paylocation = "Waiting";



                db.approvedPolicies.Add(approvedPolicy);
                db.SaveChanges();

                db.PolicyApplictions.Remove(policyAppliction);
                db.SaveChanges();


                //ShopCart.Services.Implementation.EmailService emailService = new ShopCart.Services.Implementation.EmailService();
                //emailService.SendEmail(new EmailContent()
                //{
                //    mailTo = mailTo,
                //    mailCc = new List<MailAddress>(),
                //    mailSubject = "Application Statement | Ref No.:" + owner.ownerID,
                //    mailBody = body,
                //    mailFooter = "<br/> Many Thanks, <br/> <b>Alliance</b>",
                //    mailPriority = MailPriority.High,
                //    mailAttachments = new List<Attachment>()

                //});
                //if (approvedPolicy.Campaign_ID == 2)
                //{
                //    return RedirectToAction("IndexInformationTechnology", "Home");
                //}
                //if (leaveRequest.Campaign_ID == 3)
                //{
                //    return RedirectToAction("IndexIHumanResource", "Home");

                //}
                //if (leaveRequest.Campaign_ID == 4)
                //{
                //    return RedirectToAction("IndexFinance", "Home");
                //}
                //if (leaveRequest.Campaign_ID == 5)
                //{
                //    return RedirectToAction("IndexOperations", "Home");
                //}
                //userManager.AddToRole(user.UserId , "Landlord");

                //_userManager.AddToRole(owner.UserId, "Landlord");

                //TempData["AlertMessage"] = $"{leaveRequest.Email} has been successfully approved";

                return RedirectToAction("DashboardTable1", "Home");
            }

        }

        public ActionResult Reject(int? id)
        {
            var userName = User.Identity.GetUserName();

            ApprovedPolicy approvedPolicy = new ApprovedPolicy();
            PolicyAppliction policyAppliction = db.PolicyApplictions.Where(p => p.PolicyApplictionPk == id).FirstOrDefault();

            approvedPolicy.FirstName = policyAppliction.FirstName;
            approvedPolicy.LastName = policyAppliction.LastName;
            approvedPolicy.PolicyApplictionEmail = userName;

            approvedPolicy.gender = policyAppliction.gender;
            approvedPolicy.PolicyApplictionIdNumber = policyAppliction.PolicyApplictionIdNumber;
            approvedPolicy.PolicyApplictionCellNumber = policyAppliction.PolicyApplictionCellNumber;
            approvedPolicy.PolicyApplictionAlternativeNumber = policyAppliction.PolicyApplictionAlternativeNumber;
            approvedPolicy.PolicyName = policyAppliction.PolicyName;
            approvedPolicy.PolicyMonthlyFee = policyAppliction.PolicyMonthlyFee;
            approvedPolicy.PolicyPlanDescription = policyAppliction.PolicyPlanDescription;
            approvedPolicy.PolicyPayoutAmount = policyAppliction.PolicyPayoutAmount;
            approvedPolicy.Application_Date = "Today";
            approvedPolicy.Application_Status = "Rejected";
            approvedPolicy.ApplicationPaymentAmount = 0;
            approvedPolicy.CardName = "Waiting";
            approvedPolicy.CardNumber = "Waiting";
            approvedPolicy.CVV = "Waiting";
            approvedPolicy.ExpirationDate = "Waiting";
            approvedPolicy.Paylocation = "Waiting";

            //SendEmail em = new SendEmail();
            //em.TriggerStatusSendEmail(approvedLeave);
            var userId = User;


            //SendEmail em = new SendEmail();
            //em.TriggerStatusSendEmail(approvedLeave);
            db.approvedPolicies.Add(approvedPolicy);
            db.SaveChanges();

            db.PolicyApplictions.Remove(policyAppliction);
            db.SaveChanges();
            return RedirectToAction("DashboardTable1", "Home");

        }






        // GET: PolicyApplictions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyAppliction policyAppliction = db.PolicyApplictions.Find(id);
            if (policyAppliction == null)
            {
                return HttpNotFound();
            }
            return View(policyAppliction);
        }

        // GET: PolicyApplictions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolicyApplictions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyApplictionPk,FirstName,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] PolicyAppliction policyAppliction)
        {
            if (ModelState.IsValid)
            {
                db.PolicyApplictions.Add(policyAppliction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policyAppliction);
        }

        // GET: PolicyApplictions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyAppliction policyAppliction = db.PolicyApplictions.Find(id);
            if (policyAppliction == null)
            {
                return HttpNotFound();
            }
            return View(policyAppliction);
        }

        // POST: PolicyApplictions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyApplictionPk,FirstName,LastName,gender,PolicyApplictionIdNumber,PolicyApplictionCellNumber,PolicyApplictionAlternativeNumber,PolicyApplictionAddress,PolicyName,PolicyMonthlyFee,PolicyPlanDescription,PolicyPayoutAmount,Application_Date,Application_Status,ApplicationPaymentAmount,ClassFee,CardName,CardNumber,CVV,ExpirationDate")] PolicyAppliction policyAppliction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policyAppliction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policyAppliction);
        }

        // GET: PolicyApplictions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyAppliction policyAppliction = db.PolicyApplictions.Find(id);
            if (policyAppliction == null)
            {
                return HttpNotFound();
            }
            return View(policyAppliction);
        }

        // POST: PolicyApplictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PolicyAppliction policyAppliction = db.PolicyApplictions.Find(id);
            db.PolicyApplictions.Remove(policyAppliction);
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
