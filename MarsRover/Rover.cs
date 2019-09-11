namespace MarsRover
{
    public class Rover
    {
        public Rover(IWorldGenerator worldGenerator, Position position, Direction direction)
        {
            World = worldGenerator.Generate();
            Position = position;
            Direction = direction;
        }

        public World World { get; }
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public void Command(params char[] commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'f':
                        Position = World.Move(Position, Direction);
                        break;
                    case 'b':
                        Position = World.Move(Position, Direction.Reverse());
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
    }
}
