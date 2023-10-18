using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NextGenLife.Models
{
    public class ApprovedPolicyClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApprovedPolicyClaimPK { get; set; }
        public string PolicyUserName { get; set; }
        public string PolicyReason { get; set; }
        public string PolicyStatus { get; set; }
        public DateTime PolicyClaimDate { get; set; }

        public string PolicyClaimStatus { get; set; }

        public string PolicyName { get; set; }
        public string PolicyMonthlyFee { get; set; }
        public string PolicyPlanDescription { get; set; }
        public string PolicyPayoutAmount { get; set; }
    }
}