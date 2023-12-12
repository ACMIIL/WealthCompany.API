using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Model;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;
using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.Business
{
    public interface IAgentLoginManager
    {

        #region methode 

        Task<string> UpdateOtp(string Mobile);
        //Task VerifyMobileNumber(string mobileNumber);
        Task<CheckUserModel> CheckUser(string MobileNo);
        Task<string> VerifyOTP(OTPVerifyModel oTPVerifyModel);




        #endregion
    }
}
