using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthCompany.Business
{
    public class MFWealthManager : IMFWealthManager
    {
        #region Global Variable
        private readonly IMFWealthManager _mfWealthManager;
        #endregion

        #region ctor
        public MFWealthManager(IMFWealthManager mfWealthManager)
        {
            _mfWealthManager = mfWealthManager;
        }
        #endregion
    }
}
