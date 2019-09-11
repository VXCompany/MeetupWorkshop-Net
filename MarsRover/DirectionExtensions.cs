using System;

namespace MarsRover
{
    public static class DirectionExtensions
    {
        public static Direction Reverse(this Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.East:
                    return Direction.West;
                case Direction.South:
                    return Direction.North;
                case Direction.West:
                    return Direction.East;
                default:
                    throw new ArgumentException("direction");
            }
        }
    }
}
