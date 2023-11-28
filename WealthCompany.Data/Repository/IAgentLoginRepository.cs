using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Model;

using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.Data.Repository
{
    public interface IAgentLoginRepository
    {
        #region methode 
        Task<string> UpdateOtp(string Mobile, string newOTP);
        Task<CheckUserModel> CheckUser(string MobileNo);
        Task<string> VerifyOTP(OTPVerifyModel oTPVerifyModel);

        #endregion
    }
}
