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
                var GetDetails = await _agentLoginManager.UpdateOtp(Mobile);

                _logger.LogInformation("UsersDetailsController -- GetUsersDetails");

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