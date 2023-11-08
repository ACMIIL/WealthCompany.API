using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Business.Helper
{
    public interface ISendMessageHelper
    {
        Task SendMessage(string mobileNumber, string otpMessage);
    }
}
