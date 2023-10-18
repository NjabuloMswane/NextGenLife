using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NextGenLife.Models
{
    public class ApprovedPolicy
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApprovedPolicyPk { get; set; }

        public string FirstName { get; set; }
        public string Paylocation { get; set; }

        //Personal Details
        public string LastName { get; set; }
        public string gender { get; set; }
        public string PolicyApplictionIdNumber { get; set; }
        public string PolicyApplictionCellNumber { get; set; }
        public string PolicyApplictionAlternativeNumber { get; set; }

        public string PolicyApplictionAddress { get; set; }
        public string PolicyApplictionEmail { get; set; }

        //Policy Details
        public string PolicyName { get; set; }
        public string PolicyMonthlyFee { get; set; }
        public string PolicyPlanDescription { get; set; }
        public string PolicyPayoutAmount { get; set; }

        //Appliction Detail

        [DisplayName("Application Date"), DataType(DataType.Date)]
        public string Application_Date { get; set; }
        public string Application_Status { get; set; }

        public double ApplicationPaymentAmount { get; set; }
        public double ClassFee { get; set; }

        public string calcpaymentstatus()
        {
            string name = "";
            if (ClassFee - ApplicationPaymentAmount == 0)
            {
                name = "Sucessful Payment";
            }
            else
            {
                name = "UnSucessful Payment";

            }
            return name;
        }

        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
    }
}