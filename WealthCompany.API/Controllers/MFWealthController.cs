using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WealthCompany.Business;

namespace WealthCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MFWealthController : ControllerBase
    {
        #region Global Variables
        private readonly IMFWealthManager _mfWealthManager;
        #endregion

        #region Ctor
        public MFWealthController(IMFWealthManager mfWealthManager)
        {
            _mfWealthManager = mfWealthManager;
        }
        #endregion

        #region methods

        #endregion
    }
}
