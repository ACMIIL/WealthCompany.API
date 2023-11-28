using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;
using WealthCompany.Data;

namespace WealthCompany.Service
{
    public class PMSandAIFService : IPMSandAIFService
    {
        #region Global Variables
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public PMSandAIFService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region methode 
        public async Task<string> InsertMF_AIF_Lead(MF_AIFModel mF_AIFModel)
        {
            return await _unitOfWork.PMSandAIF.InsertMF_AIF_Lead(mF_AIFModel);
        }

        #endregion
    }
}
