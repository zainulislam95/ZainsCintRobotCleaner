using Cleaner.Domain.Enum;
using Cleaner.Domain.Models;
using Cleaner.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Service.Implementations
{
    public class RobotCleanerService : IRobotCleanerService
    {
        #region Service Injection
        public IRobotInputService _reader { get; }
        public IRobotOutputService _writer { get; }
        public RobotCleanerService(IRobotInputService reader, IRobotOutputService writer)
        {
            _reader = reader;
            _writer = writer;
        }
        #endregion

        #region Functions

        public virtual void Clean()
        { 
            while (!_reader.isInputComplete)
            {
                _reader.ParseInput(_reader.ReadInput());
            }

            int posX = _reader.instruction.startPosition.x;
            int posY = _reader.instruction.startPosition.y;
             
            Robot robot = new Robot(posX, posY); 
            foreach (Movement mvr in _reader.instruction.cleaningDirections)
            {
                Direction direction = mvr.direction;
                int step = mvr.stepCount;

                robot.Move(direction, step);
            } 
            _writer.WriteOutput($"=> Cleaned: {robot.GetCleanedLocations()}");
        }

        #endregion
    }
}
