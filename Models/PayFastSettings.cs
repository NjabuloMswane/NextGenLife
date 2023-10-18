using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NextGenLife.Models
{
    public class PayFastSettings
    {
        public PayFastSettings()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int PayFastSettingPk { get; set; }    
        public string MerchantId { get; internal set; }
        public string MerchantKey { get; internal set; }
        public string PassPhrase { get; internal set; }
        public string ProcessUrl { get; internal set; }
        public string ValidateUrl { get; internal set; }
        public string ReturnUrl { get; internal set; }
        public string CancelUrl { get; internal set; }
        public string NotifyUrl { get; internal set; }
    }
}
