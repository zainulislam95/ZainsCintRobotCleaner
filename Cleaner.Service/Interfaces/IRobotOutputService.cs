using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Service.Interfaces
{
    public interface IRobotOutputService
    {
        #region Functions
        void WriteOutput(string outputResult);
        #endregion
    }
}
