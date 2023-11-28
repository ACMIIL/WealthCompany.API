using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Business.Helper;
using WealthCompany.Core.Common;
using WealthCompany.Core.Model;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;
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
            await SentOtpMobile(newOTP, Mobile);

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

        public async Task SentOtpMobile(string newOTP, string Mobile)
        {
            try
            {
                string OTPMsg = newOTP + " is your OTP. This OTP can be used only once. - www.Investmentz.com";

                
                
                    using (var client = new System.Net.WebClient())
                    {
                        client.Headers.Add("Content-Type:application/json");
                        client.Headers.Add("Accept:application/json");

                    // Adjust the following URL according to your SMS gateway documentation
                    var result = client.DownloadString("https://push3.maccesssmspush.com/servlet/com.aclwireless.pushconnectivity.listeners.TextListener?userId=acmiil&pass=acmiil&appid=acmiil&subappid=acmiil&contenttype=1&to=" + Mobile + "&from=ACMIIL&text=" + OTPMsg + "&selfid=true&alert=1&dlrreq=true");

                   // You may want to handle the result or check for success based on your SMS gateway response
                    }

            }
            catch (Exception ex)
            {
                // Log the exception for troubleshooting
                Console.WriteLine($"Error in SentOtpMobile: {ex}");
            }
        }



        #endregion
    }
}