using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WealthCompany.Business;
using WealthCompany.Core.Model;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;

namespace WealthCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMSandAIFController : ControllerBase
    {
        #region Global Variables
        private readonly IPMSandAIFManager _pMSandAIFManager;
        private readonly ILogger<PMSandAIFController> _logger;
        private readonly IConfiguration _configuration;

        #endregion

        #region Ctor
        public PMSandAIFController(
            IPMSandAIFManager pMSandAIFManager,
            ILogger<PMSandAIFController> logger,
            IConfiguration configuration)
        {
            _pMSandAIFManager = pMSandAIFManager;
            _logger = logger;
            _configuration = configuration;
        }
        #endregion
        #region Methods
        [HttpPost("InsertPMSAIFLeads")]
        public async Task<ResultModel> InsertMF_AIF_Lead(MF_AIFModel mF_AIFModel)
        {
            try
            {
                var GetDetails = await _pMSandAIFManager.InsertMF_AIF_Lead(mF_AIFModel);

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
        #endregion
    }
}
