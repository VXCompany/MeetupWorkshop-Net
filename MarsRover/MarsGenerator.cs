using System.Collections.Generic;

namespace MarsRover
{
    public class MarsGenerator : IWorldGenerator
    {
        public World Generate()
        {
            return new World(4, 4, new List<Position> { new Position(2,3), new Position(4,2) });
        }
    }
}
