using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Model;
using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.Service
{
    public interface IAgentLoginservice
    {
        #region methode 

        Task<string> UpdateOtp(string Mobile, string newOTP);
        Task<CheckUserModel> CheckUser(string MobileNo);
        Task<string> VerifyOTP(OTPVerifyModel oTPVerifyModel);
        #endregion
    }
}
