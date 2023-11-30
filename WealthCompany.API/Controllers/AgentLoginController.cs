using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WealthCompany.Business;
using WealthCompany.Core.Model;
using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AgentLoginController : ControllerBase
    {
        #region Global Variables
        private readonly IAgentLoginManager _agentLoginManager;
        private readonly ILogger<AgentLoginController> _logger;
        private readonly IConfiguration _configuration;

        #endregion

        #region Ctor
        public AgentLoginController(
            IAgentLoginManager agentLoginManager,
            ILogger<AgentLoginController> logger,
            IConfiguration configuration)
        {
            _agentLoginManager = agentLoginManager;
            _logger = logger;
            _configuration = configuration;
        }
        #endregion

        #region Methods


        [HttpPost("UpdateOTP")]
        public async Task<ResultModel> UpdateOtp(string Mobile)
        {
            try
            {
                var updateResult = await _agentLoginManager.UpdateOtp(Mobile);

                if (updateResult == "OTP_SENT_SUCCESSFULLY")
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = "OTP sent successfully.",
                        Data = null
                    };
                }
                else if (updateResult == "USER_NOT_FOUND")
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.NotFound,
                        Message = "User not found.",
                        Data = null
                    };
                }
                else if (updateResult == "FAILED_TO_UPDATE_OTP")
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Failed to update OTP.",
                        Data = null
                    };
                }
                else
                {
                    // Handle other cases if needed
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Unexpected error occurred.",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new ResultModel()
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }


        [HttpPost("CheckUser")]
        public async Task<ResultModel> CheckUser(string MobileNo)
        {
            try
            {
                var GetDetails = await _agentLoginManager.CheckUser(MobileNo);

                _logger.LogInformation("AgentLoginController -- CheckUser");

                return new ResultModel()
                {
                    Code = HttpStatusCode.OK,
                    //Message = Messages.SegmentAdditionSLBM,
                    Data = GetDetails
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new ResultModel()
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = ""
                };
            }
        }

        [HttpPost("VerifyOTP")]
        public async Task<ResultModel> VerifyOTP(OTPVerifyModel oTPVerifyModel)
        {
            try
            {
                var Verify = await _agentLoginManager.VerifyOTP(oTPVerifyModel);

                _logger.LogInformation("AgentLoginController -- CheckUser");

                return new ResultModel()
                {
                    Code = HttpStatusCode.OK,
                    //Message = Messages.SegmentAdditionSLBM,
                    Data = Verify
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new ResultModel()
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = ""
                };
            }
        }
        #endregion






    }
}