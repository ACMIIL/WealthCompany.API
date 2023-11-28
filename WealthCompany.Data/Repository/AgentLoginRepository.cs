using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Core.Configurations;
using WealthCompany.Core.Model;
using WealthCompany.Core.Model.MF_AIFLeadGenrationModel;
using static WealthCompany.Core.Model.AgentLoginModel;

namespace WealthCompany.Data.Repository
{
    public class AgentLoginRepository : IAgentLoginRepository
    {
        #region Global Variables
        private readonly IDbConnection _DBUATTWC;
        
        #endregion

        #region Ctor
        public AgentLoginRepository(IEnumerable<WealthCompany.Data.Classes.IConnection> connections)
        {

            //_dbConnection = dbConnection;

            if (connections.FirstOrDefault(x => x.Name == "DBUATTWC") != null)
            {
                _DBUATTWC = connections.FirstOrDefault(x => x.Name == "DBUATTWC").Connection;
            }
         
        }
        #endregion
        #region Method
   

        public async Task<string> UpdateOtp(string Mobile, string newOTP)
        {
            var dp = new DynamicParameters();
            dp.Add("@Mobile", Mobile);
            dp.Add("@MobileOTP", newOTP);
            //dp.Add("@MobileOTPGeneratedDate", oTP.MobileOTPGeneratedDate.ToString("MM/dd/yyyy HH:mm:ss"));
            return await _DBUATTWC.ExecuteScalarAsync<string>(
                    sql: StoredProcedure.USP_UpdateOTP,
                    param: dp,
                    commandType: CommandType.StoredProcedure);
        }


        public async Task<CheckUserModel> CheckUser(string MobileNo)
        {
            var dp = new DynamicParameters();
            dp.Add("@Mobile", MobileNo);
            dp.Add("@UserFound", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            dp.Add("@FoundMobile", dbType: DbType.String, size: 12, direction: ParameterDirection.Output);

            await _DBUATTWC.ExecuteAsync(
                sql: StoredProcedure.USP_CheckUserByMobile,
                param: dp,
                commandType: CommandType.StoredProcedure);

            // Get the values of @UserFound and @FoundMobile from the output parameters
            bool userFound = dp.Get<bool>("@UserFound");
            string foundMobile = dp.Get<string>("@FoundMobile");

            // Create a CheckUserModel based on the result
            CheckUserModel result = new CheckUserModel
            {
                UserFound = userFound,
                FoundMobile = foundMobile
            };

            return result;
        }




        public async Task<string> VerifyOTP(OTPVerifyModel oTPVerifyModel)
        {         
                var dp = new DynamicParameters();
                dp.Add("@Mobile", oTPVerifyModel.Mobile);
                dp.Add("@MobileOTP", oTPVerifyModel.MobileOTP);

                var result = await _DBUATTWC.QueryFirstOrDefaultAsync<string>(
                    sql: StoredProcedure.VerifyOTP, // Stored procedure name
                    param: dp,
                    commandType: CommandType.StoredProcedure);

                return result;
            
        }
        

        #endregion


    }
}
