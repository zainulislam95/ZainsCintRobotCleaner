using Cleaner.Domain.Enum;

namespace Cleaner.Domain.Models
{
    public class Movement
    {
        #region Variables

        public Direction direction { get; set; }
        public int stepCount { get; set; }

        #endregion
    }
}
