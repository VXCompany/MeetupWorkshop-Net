using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class World
    {
        public World(int width, int height, IEnumerable<Position> objects)
        {
            Width = width;
            Height = height;
            Objects = objects;
        }
        public int Width { get; }
        public int Height { get; }
        public IEnumerable<Position> Objects { get; }

        public Position Move(Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return GetNewPosition(position, 0, 1);
                case Direction.East:
                    return GetNewPosition(position, 1, 0);
                case Direction.South:
                    return GetNewPosition(position, 0, -1);
                case Direction.West:
                    return GetNewPosition(position, -1, 0);
                default:
                    return null;
            }
        }

        private Position GetNewPosition(Position position, int dX, int dY)
        {
            var xNew = position.X + dX;
            var yNew = position.Y + dY;

            if (xNew > Width + 1)
            {
                xNew = 1;
            }
            if (xNew < 1)
            {
                xNew = Width;
            }
            if (yNew > Height + 1)
            {
                yNew = 1;
            }
            if (yNew < 1)
            {
                yNew = Height;
            }
            if (Objects.Any(x => x.X == xNew && x.Y == yNew))
            {
                throw new BlockingObjectException("ouch");
            }

            return new Position(xNew, yNew);
        }
    }
}
