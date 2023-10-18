using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NextGenLife.Models
{
    public class PolicyPlan
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyPlanPk { get; set; }
        public string PolicyName { get; set; }
        public string PolicyMonthlyFee { get; set; }
        public string PolicyPlanDescription { get; set; }
        public string PolicyPayoutAmount { get; set; }



        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int Campaign_ID { get; set; }
        public virtual Category Category { get; set; }

    }
}