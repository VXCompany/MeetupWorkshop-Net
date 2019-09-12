using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class RandomWorldGenerator : IWorldGenerator
    {
        private readonly Random _random;
        private const int MINSIZE = 3;

        public RandomWorldGenerator()
        {
            _random = new Random();
        }
        public World Generate()
        {
            var x = _random.Next(MINSIZE, 10);
            var y = _random.Next(MINSIZE, 10);

            return new World(x, y, GetRandomObjects(x, y));
        }

        private IEnumerable<Position> GetRandomObjects(int maxX, int maxY)
        {
            var amountOfRandomObjects = _random.Next(2, 8);
            for (int i = 0; i < amountOfRandomObjects; i++)
            {
                var x = _random.Next(MINSIZE, maxX);
                var y = _random.Next(MINSIZE, maxY);
                yield return new Position(x, y);
            }
        }
    }
}
