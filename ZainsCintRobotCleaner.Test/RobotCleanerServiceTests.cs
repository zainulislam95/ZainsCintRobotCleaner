using Cleaner.Service.Implementations;
using Cleaner.Service.Interfaces;
using Moq;
using NUnit.Framework;

namespace ZainsCintRobotCleaner.Test
{
    public class RobotCleanerServiceTests
    {
        [Test]
        public void WhenRobotGivenValidInputThenCleanIsCalled()
        {
            //arrange
            var inputInstructions = new[] {
                "2",
                "10 22",
                "E 2",
                "N 1"
            };

            var mockReadInputService = new Mock<IRobotInputService>();

            //act
            mockReadInputService.Setup(r => r.ParseInput(inputInstructions[0]));
            mockReadInputService.Setup(r => r.ParseInput(inputInstructions[1]));
            mockReadInputService.Setup(r => r.ParseInput(inputInstructions[2]));
            mockReadInputService.Setup(r => r.ParseInput(inputInstructions[3]));

            var mockWriteOutputService = new Mock<IRobotOutputService>();

            var mockRobotCleanerService = new Mock<RobotCleanerService>(mockReadInputService.Object, mockWriteOutputService.Object);
            mockRobotCleanerService.Object.Clean();

            //assert
            mockRobotCleanerService.Verify(x => x.Clean(), Times.Once());
        }
    }
}
