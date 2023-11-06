using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Data.Classes
{
    public interface IConnection
    {
        public string Name { get; }
        public IDbConnection Connection { get; set; }
    }
}
