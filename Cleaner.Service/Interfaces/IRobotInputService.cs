using Cleaner.Domain.Models;

namespace Cleaner.Service.Interfaces
{
    public interface IRobotInputService
    {
        #region Variables
        List<string> robotInstructions { get; set; }
        Instruction instruction { get; set; }
        bool isInputComplete { get; }
        #endregion

        #region Functions
        string ReadInput();
        void ParseInput(string instruction);
        #endregion
    }
}
