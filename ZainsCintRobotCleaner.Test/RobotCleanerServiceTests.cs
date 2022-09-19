using Cleaner.Service.Implementations;
using Cleaner.Service.Interfaces;
using Moq;
using NUnit.Framework;

namespace ZainsCintRobotCleaner.Test
{
    public class RobotCleanerServiceTests
    {
        #region Robot Cleaner
        
        [Test]
        public void WhenRobotGivenValidInputThenCleanIsExecuted()
        {
            //arrange
            var instructions = new[] {
                "2",
                "10 22",
                "E 2",
                "N 1"
            };

            var mockRobotOutputService = new Mock<IRobotOutputService>(); 
            var mockRobotInputService = new Mock<IRobotInputService>();

            //act
            mockRobotInputService.Setup(r => r.ParseInput(instructions[0]));
            mockRobotInputService.Setup(r => r.ParseInput(instructions[1]));
            mockRobotInputService.Setup(r => r.ParseInput(instructions[2]));
            mockRobotInputService.Setup(r => r.ParseInput(instructions[3]));
             
            var mockRobotCleanerService = new Mock<RobotCleanerService>(mockRobotInputService.Object, mockRobotOutputService.Object);
            mockRobotCleanerService.Object.Clean();

            //assert
            mockRobotCleanerService.Verify(x => x.Clean(), Times.Once());
        }

        #endregion
    }
}
