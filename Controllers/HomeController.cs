using Microsoft.AspNet.Identity;
using NextGenLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NextGenLife.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult DashboardTable1()
        {
            return View();
        }
        public ActionResult DashboardClaim()
        {
            return View();
        }
        public ActionResult DashboardClaim1()
        {
            return View();
        }
        public ActionResult ClaimStatus()
        {
            return View();
        }
        public ActionResult ClaimStaus()
        {
            var userName = User.Identity.GetUserName();

            return PartialView("_ClaimStaus", db.approvedPolicyClaims.Where(X=>X.PolicyUserName==userName).ToList());
        }
        public ActionResult ApprovedPolicyLife()
        {
            return PartialView("_ApprovedPolicyLife", db.PolicyApplictions.ToList());
        }
        public ActionResult ApprovedPolicyClaim()
        {
            var userName = User.Identity.GetUserName();

            return PartialView("_ApprovedPolicyClaim", db.PolicyClaims.Where(X => X.PolicyUserName == userName).ToList());
        }
       
        public ActionResult ViewPolicyClaim()
        {
            var userName = User.Identity.GetUserName(); 
            return PartialView("_ViewPolicyClaim", db.PolicyClaims.ToList());
        }

        public ActionResult StatusApprovedPolicy()
        {
            return PartialView("_StatusApprovedPolicy", db.approvedPolicies.ToList());
        }
        public ActionResult StatusAppovedClaim()
        {
            return PartialView("_StatusAppovedClaim", db.approvedPolicyClaims.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}