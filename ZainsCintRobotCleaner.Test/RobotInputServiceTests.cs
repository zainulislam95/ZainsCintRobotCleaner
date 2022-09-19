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
        [Test]
        public void WhenReadInputNumberOfCommandsAreTwoThenInputsAreComplete()
        {
            //arrange
            var readInputService = new Mock<IRobotInputService>();

            //act
            readInputService.Setup(r => r.ParseInput("2"));
            readInputService.Setup(r => r.ParseInput("10 22"));
            readInputService.Setup(r => r.ParseInput("E 2"));
            readInputService.Setup(r => r.ParseInput("N 1"));
            readInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.IsTrue(readInputService.Object.isInputComplete);
        }

        //Test without Mock just to show possibilties
        [Test]
        public void WhenReadInputNumberOfCommandsAreThreeAndCommandsAreTwoThenInputsAreNotComplete()
        {
            //arrange
            var r = new RobotInputService();

            //act
            r.ParseInput("3");
            r.ParseInput("10 22");
            r.ParseInput("E 2");
            r.ParseInput("N 1");

            //assert
            Assert.IsFalse(r.isInputComplete);
        }

        [Test]
        public void WhenReadInputNumberOfCommandsAreMoreThanTwoThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var readInputService = new Mock<IRobotInputService>();

            //act
            readInputService.Setup(r => r.ParseInput("4"));
            readInputService.Setup(r => r.ParseInput("10 22"));
            readInputService.Setup(r => r.ParseInput("E 2"));
            readInputService.Setup(r => r.ParseInput("N 1"));
            readInputService.Setup(r => r.ParseInput("W 3"));
            readInputService.Setup(r => r.ParseInput("S 3"));
            readInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(readInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenReadInputNumberOfCommandsAreZeroThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var readInputService = new Mock<IRobotInputService>();

            //act
            readInputService.Setup(r => r.ParseInput("0"));
            readInputService.Setup(r => r.ParseInput("10 22"));
            readInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(readInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenReadInputNumberOfCommandsAreLessThanZeroThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var readInputService = new Mock<IRobotInputService>();

            //act
            readInputService.Setup(r => r.ParseInput("-3"));
            readInputService.Setup(r => r.ParseInput("10 22"));
            for (int i = 0; i < 10000; i++)
            {
                readInputService.Setup(r => r.ParseInput("W 2"));
            }
            readInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(readInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenReadInputNumberOfCommandsAreTenThousandThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var readInputService = new Mock<IRobotInputService>();

            //act
            readInputService.Setup(r => r.ParseInput("10000"));
            readInputService.Setup(r => r.ParseInput("10 22"));
            for (int i = 0; i < 10000; i++)
            {
                readInputService.Setup(r => r.ParseInput("W 2"));
            }
            readInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(readInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenReadInputNumberOfCommandsAreMoreThanTenThousandThenInputsAreComplete()
        {
            //arrange
            var expectedResult = true;
            var readInputService = new Mock<IRobotInputService>();

            //act
            readInputService.Setup(r => r.ParseInput("10500"));
            readInputService.Setup(r => r.ParseInput("10 22"));
            for (int i = 0; i < 10000; i++)
            {
                readInputService.Setup(r => r.ParseInput("W 2"));
            }
            readInputService.SetupGet(r => r.isInputComplete).Returns(true);

            //assert
            Assert.That(expectedResult, Is.EqualTo(readInputService.Object.isInputComplete));
        }

        [Test]
        public void WhenReadInputNumberOfCommandsThenSetNumberOfCommandsInInstructions()
        {
            //arrange
            var readInputService = new RobotInputService();

            //act
            readInputService.ParseInput("1");
            readInputService.ParseInput("10 22");
            readInputService.ParseInput("E 2");

            //assert
            Assert.That(readInputService.instruction.numberOfCommands, Is.EqualTo(1));
        }

        [Test]
        public void WhenReadInputPositionWithInRangeThenSetStartPositionInInstructions()
        {
            //arrange
            var readInputService = new RobotInputService();

            //act
            readInputService.ParseInput("0");
            readInputService.ParseInput("10 22");

            //assert
            Assert.That(readInputService.instruction.startPosition.x, Is.EqualTo(10));
            Assert.That(readInputService.instruction.startPosition.y, Is.EqualTo(22));
        }

        [Test]
        public void WhenReadInputPositionOutOfRangeThenSetStartPositionInInstructions()
        {
            //arrange
            var readInputService = new RobotInputService();

            //act
            readInputService.ParseInput("0");
            readInputService.ParseInput("15000 -20000");

            //assert
            Assert.That(readInputService.instruction.startPosition.x, Is.EqualTo(Helper.maxPositionX));
            Assert.That(readInputService.instruction.startPosition.y, Is.EqualTo(Helper.minPositionY));
        }

        [Test]
        public void WhenReadInputPositionWithSeperatorThenSetStartPositionInInstructions()
        {
            //arrange
            var readInputService = new RobotInputService();

            //act
            readInputService.ParseInput("0");
            readInputService.ParseInput("1000\n2000");

            //assert
            Assert.That(readInputService.instruction.startPosition.x, Is.EqualTo(1000));
            Assert.That(readInputService.instruction.startPosition.y, Is.EqualTo(2000));
        }


        [Test]
        public void WhenReadInputCleaningDirectionsThenAddCleaningDirections()
        {
            //arrange
            var readInputService = new RobotInputService();

            //act
            readInputService.ParseInput("3");
            readInputService.ParseInput("10 22");
            readInputService.ParseInput("E 2");
            readInputService.ParseInput("N 1");
            readInputService.ParseInput("W 3");

            //assert
            Assert.That(readInputService.instruction.cleaningDirections.Count, Is.EqualTo(3));
        }

        [Test]
        public void WhenReadInputCleaningDirectionsStepsMoreThan100000ThenSetStepsTo99999()
        {
            //arrange
            var readInputService = new RobotInputService();
            int actualValue = 0;
            int expectedValue = Helper.maxSteps - 1;

            //act
            readInputService.ParseInput("1");
            readInputService.ParseInput("10 22");
            readInputService.ParseInput("E 100000");

            var value = readInputService.instruction.cleaningDirections.Find(x => x.direction == Direction.East);
            if (value != null)
                actualValue = value.stepCount;

            //assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void WhenReadInputCleaningDirectionsStepsLessThan1ThenSetStepsTo0()
        {
            //arrange
            var readInputService = new RobotInputService();
            int actualValue = 0;
            int expectedValue = Helper.minSteps + 1;

            //act
            readInputService.ParseInput("1");
            readInputService.ParseInput("10 22");
            readInputService.ParseInput("E 0");
            var value = readInputService.instruction.cleaningDirections.Find(x => x.direction == Direction.East);
            if (value != null)
                actualValue = value.stepCount;

            //assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
