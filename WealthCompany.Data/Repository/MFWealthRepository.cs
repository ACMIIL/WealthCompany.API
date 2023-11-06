using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Data.Repository
{
    public class MFWealthRepository : IMFWealthRepository
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Ctor
        public MFWealthRepository(IEnumerable<WealthCompany.Data.Classes.IConnection> connections)
        {
            if (connections.FirstOrDefault(x => x.Name == "AcmCompare") != null)
            {
                _dbConnection = connections.FirstOrDefault(x => x.Name == "AcmCompare").Connection;
            }
        }
        #endregion
    }
}
