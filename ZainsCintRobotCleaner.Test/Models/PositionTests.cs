using Cleaner.Domain.Enum;
using Cleaner.Domain.Models;
using NUnit.Framework;

namespace ZainsCintRobotCleaner.Test.Models
{
    public class PositionTests
    {
        [TestCase(60, 70)]
        [TestCase(800, -9000)]
        [TestCase(9000, 10000)]
        public void WhenPositionCreatedCoordinatesShouldBeSetProperly(int xPos, int yPos)
        {
            //arrange

            //act
            var directionPoint = new Position(xPos, yPos);

            //assert
            Assert.That(directionPoint.x, Is.EqualTo(xPos));
            Assert.That(directionPoint.y, Is.EqualTo(yPos));
        }

        [Theory]
        [TestCase(Direction.North, 0, 1)]
        public void WhenGetNeighborLocationWithValidInputThenGetValidResult(Direction direction, int expectedX, int expectedY)
        {
            //arrange
            var position = new Position(0, 0);

            //act
            var directionPoint = position.GetDirectionPosition(direction);

            //check
            Assert.That(directionPoint.x, Is.EqualTo(expectedX));
            Assert.That(directionPoint.y, Is.EqualTo(expectedY));
        }

        [Theory]
        [TestCase(Direction.Unknown, 0, 1)]
        public void WhenGetNeighborLocationWithInValidInputThenGetValidResult(Direction direction, int expectedX, int expectedY)
        {
            //arrange
            var position = new Position(0, 1);

            //act
            var directionPoint = position.GetDirectionPosition(direction);

            //check
            Assert.That(directionPoint.x, Is.EqualTo(expectedX));
            Assert.That(directionPoint.y, Is.EqualTo(expectedY));
        }
    }
}
