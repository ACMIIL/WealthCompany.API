using WealthCompany.Core.Model;

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
