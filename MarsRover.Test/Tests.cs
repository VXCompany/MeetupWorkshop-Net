using FluentAssertions;
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

            rover.Move('f', 'b');

            rover.Position.X.Should().Be(1);
        }

        [Fact(DisplayName = "Rover moves one to the north on forward")]
        public void MoveForward()
        {
            var rover = GetRover();
            rover.Move('f');

            rover.Position.Y.Should().Be(2);
        }

        [Fact(DisplayName = "Rover moves one to the south on backward")]
        public void MoveBackward()
        {
            var rover = GetRover();
            rover.Move('b');

            rover.Position.Y.Should().Be(0);
        }

        private Rover GetRover()
        {
            var marsGenerator = new MarsGenerator();
            return new Rover(marsGenerator, new Position(1, 1), Direction.North);
        }
    }
}
