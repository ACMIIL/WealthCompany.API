using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;

namespace WealthCompany.Data.Repository
{
    public interface IPMSandAIFRepository
    {
        Task<string> InsertMF_AIF_Lead(MF_AIFModel mF_AIFModel);
    }
}
