using Cleaner.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Service.Implementations
{ 
    public class RobotOutputService : IRobotOutputService
    {
        #region Functions
        public void WriteOutput(string outputResult) => Console.WriteLine(outputResult);
        #endregion
    }
}
