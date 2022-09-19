namespace Cleaner.Domain.Models
{
    public class Instruction
    {
        #region Variables

        public int numberOfCommands { get; set; }
        public Position startPosition { get; set; }
        public List<Movement> cleaningDirections { get; set; }

        #endregion

        #region Constructor

        public Instruction()
        {
            cleaningDirections = new List<Movement>();
        }

        #endregion
    }
}
