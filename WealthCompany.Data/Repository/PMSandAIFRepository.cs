using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Configurations;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;

namespace WealthCompany.Data.Repository
{
    public class PMSandAIFRepository : IPMSandAIFRepository
    {
            
        #region Global Variables
        private readonly IDbConnection _DBUATTWC;

        #endregion

        #region Ctor
        public PMSandAIFRepository(IEnumerable<WealthCompany.Data.Classes.IConnection> connections)
        {

            //_dbConnection = dbConnection;

            if (connections.FirstOrDefault(x => x.Name == "DBUATTWC") != null)
            {
                _DBUATTWC = connections.FirstOrDefault(x => x.Name == "DBUATTWC").Connection;
            }

        }
        #endregion
        #region Method
        public async Task<string> InsertMF_AIF_Lead(MF_AIFModel mF_AIFModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@Full_Name", mF_AIFModel.Full_Name);
            dp.Add("@Min_Investment", mF_AIFModel.Min_Investment);
            dp.Add("@@Mobile_Number", mF_AIFModel.Mobile_No);
            dp.Add("@Email_ID", mF_AIFModel.Email_ID);

                return  await _DBUATTWC.QueryFirstOrDefaultAsync<string>(
                sql: StoredProcedure.InsertInvestor, // Stored procedure name
                param: dp,
                commandType: CommandType.StoredProcedure);

            

        }

        #endregion
    }
}
