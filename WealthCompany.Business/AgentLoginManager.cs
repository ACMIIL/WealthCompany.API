using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Business.Helper;
using WealthCompany.Core.Common;
using WealthCompany.Core.Model;
using WealthCompany.Service;
using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.Business
{
    public class AgentLoginManager : IAgentLoginManager
    {
        #region Global Variables
        private readonly IAgentLoginservice _agentLoginservice;
        private readonly ISendMessageHelper _sendMessageHelper;

        #endregion

        #region Ctor
        public AgentLoginManager(IAgentLoginservice AgentLoginservice,
            ISendMessageHelper sendMessageHelper
           )
        {
            _agentLoginservice = AgentLoginservice;
            _sendMessageHelper = sendMessageHelper;
        }
        #endregion
        #region methode 

        public async Task<string> UpdateOtp(string Mobile)
        {

            // Check if the user exists
            CheckUserModel checkUserResult = await CheckUser(Mobile);

            string newOTP = GenerateOTP();

            // Send Message for OTP
            string otpMessage = StaticValues.OTPMessage.Replace("#OTP#", newOTP);


            // Send Physical Message on Mobile
            await _sendMessageHelper.SendMessage(Mobile, otpMessage);


            if (checkUserResult.UserFound)
            {
               
                return await _agentLoginservice.UpdateOtp(Mobile, newOTP);
            }
            else
            {
                // User not found, return a message
                return "User not found.";
            }
        }

        public async Task<string> VerifyOTP(OTPVerifyModel oTPVerifyModel)
        {
            return await _agentLoginservice.VerifyOTP(oTPVerifyModel);
        }




        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP.
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public async Task<CheckUserModel> CheckUser(string MobileNo)
        {
            return await _agentLoginservice.CheckUser(MobileNo);
        }



        #endregion
    }
}