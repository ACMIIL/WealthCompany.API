using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Data.Classes
{
    public class AcmCompareConnection : IConnection
    {
        public AcmCompareConnection(IDbConnection connection)
        {
            Connection = connection;
        }

        public string Name
        {
            get { return "AcmCompare"; }
        }
        public IDbConnection Connection { get; set; }
    }
}
