using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Business.Helper;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;
using WealthCompany.Service;

namespace WealthCompany.Business
{
    public class PMSandAIFManager : IPMSandAIFManager
    {
        #region Global Variables
        private readonly IPMSandAIFService _pMSandAIFService;
        

        #endregion

        #region Ctor
        public PMSandAIFManager(IPMSandAIFService pMSandAIFService
            
           )
        {
            _pMSandAIFService = pMSandAIFService;
            
        }
        #endregion
        #region methode 




        public async Task<string> InsertMF_AIF_Lead(MF_AIFModel mF_AIFModel)
        {
            return await _pMSandAIFService.InsertMF_AIF_Lead(mF_AIFModel);
        }



         #endregion
    }
}
