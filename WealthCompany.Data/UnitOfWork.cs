using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Data.Repository;

namespace WealthCompany.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Global Variables
        public IAgentLoginRepository AgentLogin { get; }
        public IPMSandAIFRepository PMSandAIF { get; }
        #endregion

        public UnitOfWork(IAgentLoginRepository agentLoginRepository,

           IPMSandAIFRepository pMSandAIFRepository )
        {
            AgentLogin = agentLoginRepository;
            PMSandAIF = pMSandAIFRepository;    
        }
        



    }
} 
    
