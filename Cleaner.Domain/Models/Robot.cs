using Cleaner.Domain.Enum;

namespace Cleaner.Domain.Models
{
    public class Robot
    { 
        #region Variables

        private HashSet<Position> cleanedLocations { get; set; }

        private Position _currentLocation; 
        public Position currentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;

                if (cleanedLocations == null)
                    cleanedLocations = new HashSet<Position>();

                cleanedLocations.Add(currentLocation); 
            }
        }

        #endregion

        #region Constructor

        public Robot(int xPos, int yPos)
        {
            currentLocation = new Position(xPos, yPos);
        }

        #endregion

        #region Functions

        public void Move(Direction direction, int step)
        {
            while (step >= 1)
            {
                currentLocation = currentLocation.GetDirectionPosition(direction);

                step--;
            }
        }  
        public int GetCleanedLocations()
        {
            return cleanedLocations.Count;
        }

        #endregion
    }
}
