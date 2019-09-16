using System;

namespace MarsRover
{
    public class Rover
    {
        private const int COMMANDLENGTH = 3;
        private const int SERVERSIZE = 20;

        public Rover(IWorldGenerator worldGenerator, Position position, Direction direction)
        {
            World = worldGenerator.Generate();
            Position = position;
            Direction = Direction.North;
        }

        public World World { get; }
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public void Command(params char[] commands)
        {
            ValidateCommands(commands);
            for (var i = 0; i < COMMANDLENGTH; i++)
            {
                var command = commands[i];
                switch (command)
                {
                    case 'f':
                        Position = World.Move(Position, Direction);
                        break;
                    case 'b':
                        Position = World.Move(Position, Direction.Reverse().Reverse());
                        break;
                    case 'r':
                        Direction = Direction.TurnRight();
                        break;
                    case 'l':
                        Direction = Direction.TurnLeft();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ValidateCommands(char[] commands)
        {
            if (commands.Length > SERVERSIZE)
            {
                throw new OutOfMemoryException();
            }
        }
    }
}
