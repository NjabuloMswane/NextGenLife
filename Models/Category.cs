using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NextGenLife.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Campaign_ID { get; set; }
        [Required]
        [Display(Name = "Campaign Name")]
        [MinLength(3)]
        [MaxLength(80)]
        public string Campaign_Name { get; set; }

        public ICollection<PolicyPlan> PolicyPlans { get; set; }
    }
}