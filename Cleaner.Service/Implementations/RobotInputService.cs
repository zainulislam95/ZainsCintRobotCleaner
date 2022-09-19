using Cleaner.Domain.Enum;
using Cleaner.Domain.Models;
using Cleaner.Service.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Service.Implementations
{
    public class RobotInputService : IRobotInputService
    {
        #region Variables 
        public List<string> robotInstructions { get; set; } 
        public Instruction instruction { get; set; }
        public bool isInputComplete
        {
            get {
                if (robotInstructions.Count == (instruction.numberOfCommands + 2))
                    return true;
                else
                    return false;
                    //return (robotInstructions.Count == (instruction.numberOfCommands + 2)); 
            } 
        } 
        #endregion

        #region Constructor
        public RobotInputService()
        {
            robotInstructions = new List<string>();
            instruction = new Instruction();
        }
        #endregion 

        #region Functions
        public string ReadInput()
        {
            return Console.ReadLine()!;
        }
        public void ParseInput(string instruction)
        {
            if (!isInputComplete)
            {
                if (robotInstructions.Count == 0)
                {
                    SetRobotCommands(instruction);
                }
                else if (robotInstructions.Count == 1)
                {
                    SetStartPosition(instruction);
                }
                else
                {
                    SetCleaningDirections(instruction);
                }
            }
            robotInstructions.Add(instruction);
        }

        private void SetRobotCommands(string robotInstruction)
        {
            int numberOfCommands = int.Parse(robotInstruction);

            instruction.numberOfCommands = (numberOfCommands < Helper.MinNumberOfCommands) ? Helper.MinNumberOfCommands : (numberOfCommands > Helper.MaxNumberOfCommands) ? Helper.MaxNumberOfCommands : numberOfCommands;
        }
        private void SetStartPosition(string inputInstruction)
        {
            string[] coordinates = inputInstruction.Split(null);
            if (coordinates.Length > 1)
            {
                int x = int.Parse(coordinates[0]);
                x = (x >= Helper.MaxForPositionX) ? Helper.MaxForPositionX : (x <= Helper.MinForPositionX) ? Helper.MinForPositionX : x;

                int y = int.Parse(coordinates[1]);
                y = (y >= Helper.MaxForPositionY) ? Helper.MaxForPositionY : (y <= Helper.MinForPositionY) ? Helper.MinForPositionY : y;

                instruction.startPosition = new Position(x, y);
            }
        }
        private void SetCleaningDirections(string inputInstruction)
        {
            Movement movement = new Movement();

            string[] cleaningDirection = inputInstruction.Split(null); 
             
            if (cleaningDirection.Length > 1)
            {
                switch (cleaningDirection[0].ToUpper())
                {
                    case "N":
                        movement.direction = Direction.North;
                        break;
                    case "S":
                        movement.direction = Direction.South;
                        break;
                    case "E":
                        movement.direction = Direction.East;
                        break;
                    case "W":
                        movement.direction = Direction.West;
                        break;
                    default:
                        movement.direction = Direction.Unknown;
                        break;
                }

                movement.stepCount = int.Parse(cleaningDirection[1]);
                movement.stepCount = (movement.stepCount >= Helper.MaxNumberOfSteps) ? (Helper.MaxNumberOfSteps - 1) : (movement.stepCount <= Helper.MinNumberOfSteps) ? (Helper.MinNumberOfSteps + 1) : movement.stepCount;
            }
            instruction.cleaningDirections.Add(movement);
        }
        
        #endregion
    }
}
