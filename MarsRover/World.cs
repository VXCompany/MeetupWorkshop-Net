namespace MarsRover
{
    public class World
    {
        public Position Move(Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new Position(position.X, position.Y + 1);
                case Direction.East:
                    return new Position(position.X + 1, position.Y);
                case Direction.South:
                    return new Position(position.X, position.Y - 1);
                case Direction.West:
                    return new Position(position.X - 1, position.Y);
                default:
                    return null;
            }
        }
    }
}
