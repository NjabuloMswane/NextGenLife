using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextGenLife.Controllers
{
    public class payFastSetting
    {
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