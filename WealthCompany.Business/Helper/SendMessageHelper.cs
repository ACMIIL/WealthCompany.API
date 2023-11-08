using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Configurations;

namespace WealthCompany.Business.Helper
{
    public class SendMessageHelper :ISendMessageHelper
    {
        #region Global Variables
        private readonly ILogger<SendMessageHelper> _logger;
        private readonly AppSettings _appSettings;
        #endregion

        #region Ctor
        public SendMessageHelper(ILogger<SendMessageHelper> logger,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Methods
        public async Task SendMessage(string mobileNumber, string otpMessage)
        {
            try
            {
                // ToDo: Get from Config table
                string requestURL = $"{_appSettings.SendSMS.ACLApiUrl}" +
                                    $"?enterpriseid={_appSettings.SendSMS.ACLEnterpriseId}" +
                                    $"&subEnterpriseid={_appSettings.SendSMS.ACLEnterpriseId}" +
                                    $"&pusheid={_appSettings.SendSMS.ACLEnterpriseId}" +
                                    $"&pushepwd={_appSettings.SendSMS.ACLPwd}" +
                                    $"&sender={_appSettings.SendSMS.ACLSender}" +
                                    $"&msisdn={mobileNumber}" +
                                    $"&msgtext={otpMessage}";

                using HttpClient client = new HttpClient();
                var responseBody = await client.GetAsync(requestURL);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
#endregion

    }
}
