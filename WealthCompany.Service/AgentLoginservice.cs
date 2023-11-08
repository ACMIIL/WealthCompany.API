using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Model;
using WealthCompany.Data;
using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.Service
{
    public class AgentLoginservice : IAgentLoginservice
    {
        #region Global Variables
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public AgentLoginservice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region methode 



        public async Task<string> UpdateOtp(string Mobile, string newOTP)
        {
            return await _unitOfWork.AgentLogin.UpdateOtp(Mobile, newOTP);
        }


        public async Task<CheckUserModel> CheckUser(string MobileNo)
        {
            return await _unitOfWork.AgentLogin.CheckUser(MobileNo);
        }

        public async Task<string> VerifyOTP(OTPVerifyModel oTPVerifyModel)
        {
            return await _unitOfWork.AgentLogin.VerifyOTP(oTPVerifyModel);
        }


        #endregion


    }
}


