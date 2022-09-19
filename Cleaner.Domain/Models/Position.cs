using Cleaner.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Domain.Models
{
    public class Position
    { 
        #region Variables

        public int x { get; }
        public int y { get; }

        #endregion

        #region Constructor

        public Position(in int xPos, in int yPos)
        {
            x = xPos;
            y = yPos;
        }

        #endregion 

        #region Functions

        public Position GetDirectionPosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return new Position(x + 1, y);
                case Direction.West:
                    return new Position(x - 1, y);
                case Direction.North:
                    return new Position(x, y + 1);
                case Direction.South:
                    return new Position(x, y - 1);
                default:
                    return new Position(x, y);
            }
        }
        public override int GetHashCode()
        {
            return $"{x}-{y}".GetHashCode();
        }
        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return x == other.x && y == other.y;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            if (obj.GetType() != this.GetType()) 
                return false;
            return Equals((Position)obj);
        }  

        #endregion
    }
}
