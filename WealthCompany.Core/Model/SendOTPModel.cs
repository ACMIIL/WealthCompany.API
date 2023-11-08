using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Core.Model
{
    public class SendOTPModel
    {
        public string MobileNo { get; set; }
        public string OTPMsg { get; set; }


    }

    public class CheckUserModel
    {
        public string MobileNo { get; set; }
        public bool UserFound { get; set; }
    }
}
