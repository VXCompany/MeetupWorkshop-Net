using FluentAssertions;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class Tests
    {

        [Fact(DisplayName = "Rover should have a world")]
        public void InitializeRover()
        {
            var rover = GetRover();
            rover.World.Should().NotBeNull();
        }

        [Fact(DisplayName = "Rover recieve command")]
        public void RoverCommands()
        {
            var rover = GetRover();

            rover.Command('f', 'b');

            rover.Position.X.Should().Be(1);
        }

        [Fact(DisplayName = "Rover moves one to the north on forward")]
        public void MoveForward()
        {
            var rover = GetRover();
            rover.Command('f');

            rover.Position.Y.Should().Be(2);
        }

        [Fact(DisplayName = "Rover moves one to the south on backward")]
        public void MoveBackward()
        {
            var rover = GetRover(y: 2);
            rover.Command('b');

            rover.Position.Y.Should().Be(1);
        }

        [Fact(DisplayName = "Rover can turn right")]
        public void TurnRight()
        {
            var rover = GetRover();
            rover.Command('r');

            rover.Direction.Should().Be(Direction.East);
            rover.Command('r');

            rover.Direction.Should().Be(Direction.South);
            rover.Command('r');

            rover.Direction.Should().Be(Direction.West);
            rover.Command('r');

            rover.Direction.Should().Be(Direction.North);
        }

        [Fact(DisplayName = "Rover can turn left")]
        public void TurnLeft()
        {
            var rover = GetRover();
            rover.Command('l');

            rover.Direction.Should().Be(Direction.West);
            rover.Command('l');

            rover.Direction.Should().Be(Direction.South);
            rover.Command('l');

            rover.Direction.Should().Be(Direction.East);
            rover.Command('l');

            rover.Direction.Should().Be(Direction.North);
        }

        [Fact(DisplayName = "Rover can wrap from the edge")]
        public void WrapsY()
        {
            var rover = GetRover();
            rover.Command('b');

            rover.Position.Y.Should().Be(4);
        }

        [Fact(DisplayName = "Rover can wrap from the edge")]
        public void WrapsX()
        {
            var rover = GetRover(direction: Direction.West);
            rover.Command('f');

            rover.Position.X.Should().Be(4);
        }

        [Fact(DisplayName = "Hitting an obstacle should throw and exception")]
        public void HitObstacle()
        {
            var rover = GetRover(x: 2, y: 2, direction: Direction.North);
            Action act = () => rover.Command('f');

            act.Should().Throw<BlockingObjectException>();
        }

        private Rover GetRover(int x = 1, int y = 1, Direction direction = Direction.North)
        {
            var marsGenerator = new MarsGenerator();
            return new Rover(marsGenerator, new Position(x, y), direction);
        }
    }
}
