using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Domain.Models
{
    public class Helper
    {
        #region Commands Constants

        public const int MinNumberOfCommands = 0; 
        public const int MaxNumberOfCommands = 10000;

        #endregion

        #region Position X Coordinates Constants

        public const int MinForPositionX = -10000; 
        public const int MaxForPositionX = 10000;

        #endregion

        #region Position Y Coordinates Constants
        
        public const int MinForPositionY = -10000; 
        public const int MaxForPositionY = 10000;

        #endregion

        #region Steps Constants 

        public const int MinNumberOfSteps = 0; 
        public const int MaxNumberOfSteps = 100000;

        #endregion

    }
}
