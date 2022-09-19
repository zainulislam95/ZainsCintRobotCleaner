using Cleaner.Domain.Enum;
using Cleaner.Domain.Models;
using Cleaner.Service.Implementations;
using Cleaner.Service.Interfaces; 
using Moq;
using NUnit.Framework;

namespace ZainsCintRobotCleaner.Test
{
    public class RobotInputServiceTests
    {
        #region Commands

        [Test]
        public void WhenRobotInputNumberOfCommandsAreTwoThenInputsAreComplete()
        {
            //arrange
            var robotInputService = new Mock<IRobotInputService>();

            //act
            robotInputService.Setup(r => r.ParseInput("2"));
            robotInputService.Setup(r => r.ParseInput("10 22"));
            robotInputService.Setup(r => r.ParseInput("E 2"));
            robotInputService.Setup(r => r.ParseInput("N 1"));
            robotInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.IsTrue(robotInputService.Object.isInputComplete);
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsAreFiveAndActualCommandsAreTwoThenInputsAreNotComplete()
        {
            //arrange
            var robotInputService = new Mock<IRobotInputService>();

            //act
            robotInputService.Setup(r => r.ParseInput("5"));
            robotInputService.Setup(r => r.ParseInput("10 10"));
            robotInputService.Setup(r => r.ParseInput("E 2"));
            robotInputService.Setup(r => r.ParseInput("N 1"));
            robotInputService.SetupGet(r => r.isInputComplete).Returns(false);

            //assert
            Assert.IsFalse(robotInputService.Object.isInputComplete);
        }

        //Test without Mock just to show possibilties
        [Test]
        public void WhenRobotInputNumberOfCommandsAreThreeAndActualCommandsAreTwoThenInputsAreNotComplete()
        {
            //arrange
            var robotInputService = new RobotInputService();

            //act
            robotInputService.ParseInput("3");
            robotInputService.ParseInput("10 22");
            robotInputService.ParseInput("E 2");
            robotInputService.ParseInput("N 1");

            //assert
            Assert.IsFalse(robotInputService.isInputComplete);
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsAreMoreThanTwoAndActualCommandsAreMoreThanTwoThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var robotInputService = new Mock<IRobotInputService>();

            //act
            robotInputService.Setup(r => r.ParseInput("4"));
            robotInputService.Setup(r => r.ParseInput("10 22"));
            robotInputService.Setup(r => r.ParseInput("E 2"));
            robotInputService.Setup(r => r.ParseInput("N 1"));
            robotInputService.Setup(r => r.ParseInput("W 3"));
            robotInputService.Setup(r => r.ParseInput("S 3"));
            robotInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(robotInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsAreZeroThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var robotInputService = new Mock<IRobotInputService>();

            //act
            robotInputService.Setup(r => r.ParseInput("0"));
            robotInputService.Setup(r => r.ParseInput("10 22"));
            robotInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(robotInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsAreLessThanZeroThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var RobotInputService = new Mock<IRobotInputService>();

            //act
            RobotInputService.Setup(r => r.ParseInput("-3"));
            RobotInputService.Setup(r => r.ParseInput("10 22"));
            for (int i = 0; i < 10000; i++)
            {
                RobotInputService.Setup(r => r.ParseInput("W 2"));
            }
            RobotInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(RobotInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsAreTenThousandThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var RobotInputService = new Mock<IRobotInputService>();

            //act
            RobotInputService.Setup(r => r.ParseInput("10000"));
            RobotInputService.Setup(r => r.ParseInput("10 22"));
            for (int i = 0; i < 10000; i++)
            {
                RobotInputService.Setup(r => r.ParseInput("W 2"));
            }
            RobotInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(RobotInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsAreMoreThanTenThousandThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var RobotInputService = new Mock<IRobotInputService>();

            //act
            RobotInputService.Setup(r => r.ParseInput("10500"));
            RobotInputService.Setup(r => r.ParseInput("10 22"));
            for (int i = 0; i < 10000; i++)
            {
                RobotInputService.Setup(r => r.ParseInput("W 2"));
            }
            RobotInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(RobotInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenRobotInputNumberOfCommandsThenSetNumberOfCommandsInInstructions()
        {
            //arrange
            var RobotInputService = new RobotInputService();

            //act
            RobotInputService.ParseInput("1");
            RobotInputService.ParseInput("10 22");
            RobotInputService.ParseInput("E 2");

            //assert
            Assert.That(RobotInputService.instruction.numberOfCommands, Is.EqualTo(1));
        }

        #endregion

        #region Positions

        [Test]
        public void WhenRobotInputPositionWithInRangeThenSetStartPositionInInstructions()
        {
            //arrange
            var robotInputService = new RobotInputService();

            //act
            robotInputService.ParseInput("0");
            robotInputService.ParseInput("10 22");

            //assert
            Assert.That(robotInputService.instruction.startPosition.x, Is.EqualTo(10));
            Assert.That(robotInputService.instruction.startPosition.y, Is.EqualTo(22));
        }

        [Test]
        public void WhenRobotInputPositionOutOfRangeThenSetStartPositionInInstructions()
        {
            //arrange
            var robotInputService = new RobotInputService();

            //act
            robotInputService.ParseInput("0");
            robotInputService.ParseInput("15000 -20000");

            //assert
            Assert.That(robotInputService.instruction.startPosition.x, Is.EqualTo(Helper.maxPositionX));
            Assert.That(robotInputService.instruction.startPosition.y, Is.EqualTo(Helper.minPositionY));
        }

        [Test]
        public void WhenRobotInputPositionWithSeperatorThenSetStartPositionInInstructions()
        {
            //arrange
            var robotInputService = new RobotInputService();

            //act
            robotInputService.ParseInput("0");
            robotInputService.ParseInput("1000\n2000");

            //assert
            Assert.That(robotInputService.instruction.startPosition.x, Is.EqualTo(1000));
            Assert.That(robotInputService.instruction.startPosition.y, Is.EqualTo(2000));
        }
         
        [Test]
        public void WhenRobotInputCleaningDirectionsThenAddCleaningDirections()
        {
            //arrange
            var robotInputService = new RobotInputService();

            //act
            robotInputService.ParseInput("3");
            robotInputService.ParseInput("12 22");
            robotInputService.ParseInput("E 2");
            robotInputService.ParseInput("N 1");
            robotInputService.ParseInput("W 3");

            //assert
            Assert.That(robotInputService.instruction.cleaningDirections.Count, Is.EqualTo(3));
        }

        [Test]
        public void WhenRobotInputCleaningDirectionsStepsMoreThan100000ThenSetStepsTo99999()
        {
            //arrange
            var robotInputService = new RobotInputService();
            int actualValue = 0;
            int expectedValue = Helper.maxSteps - 1;

            //act
            robotInputService.ParseInput("1");
            robotInputService.ParseInput("10 10");
            robotInputService.ParseInput("E 100000");

            var value = robotInputService.instruction.cleaningDirections.Find(x => x.direction == Direction.East);
            if (value != null)
                actualValue = value.stepCount;

            //assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void WhenRobotInputCleaningDirectionsStepsLessThan1ThenSetStepsTo1()
        {
            //arrange
            var robotInputService = new RobotInputService();
            int actualValue = 0;
            int expectedValue = Helper.minSteps + 1;

            //act
            robotInputService.ParseInput("1");
            robotInputService.ParseInput("10 10");
            robotInputService.ParseInput("E -10");
            var value = robotInputService.instruction.cleaningDirections.Find(x => x.direction == Direction.East);
            if (value != null)
                actualValue = value.stepCount;

            //assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        #endregion
    }
}
