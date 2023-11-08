using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Core.Model
{
    public class AgentLoginModel
    {

        public class OTP
        {
            public string Mobile { get; set; }
            public string MobileOTP { get; set; }
            public DateTime MobileOTPGeneratedDate { get; set; }
        }
        public class OTPRequest
        {
            public Guid UserId { get; set; }
            public string PhoneNumber { get; set; }
            public string UserOTP { get; set; }
        }



    }
}
