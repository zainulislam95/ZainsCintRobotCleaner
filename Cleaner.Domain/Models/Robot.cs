using Cleaner.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Robot(int x, int y)
        {
            currentLocation = new Position(x, y);
        }

        #endregion

        #region Functions

        public void Move(Direction direction, int step)
        {
            while (step >= 1)
            {
                currentLocation = currentLocation.GetDirectionLocation(direction);

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
