using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NextGenLife.Models
{
    public class PolicyClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyClaimPK { get; set; }
        public string PolicyUserName { get; set; }
        public string PolicyReason { get; set; }
        public string PolicyStatus { get; set; }
        public DateTime PolicyClaimDate { get; set; }


        public string PolicyName { get; set; }
        public string PolicyMonthlyFee { get; set; }
        public string PolicyPlanDescription { get; set; }
        public string PolicyPayoutAmount { get; set; }
    }
}