using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Data.Repository;

namespace WealthCompany.Data
{
    public interface IUnitOfWork
    {
        IAgentLoginRepository AgentLogin { get; }
    }
}
