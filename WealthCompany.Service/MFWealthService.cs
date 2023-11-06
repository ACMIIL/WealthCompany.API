using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthCompany.Data;

namespace WealthCompany.Service
{
    public class MFWealthService : IMFWealthServices
    {
        #region Global Variables
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public MFWealthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
