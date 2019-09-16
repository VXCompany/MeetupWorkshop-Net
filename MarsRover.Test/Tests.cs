using Xunit;

namespace MarsRover.Test
{
    public class Tests
    {
        //Succes!

        [Fact(DisplayName = "I can create a Rover")]
        public void ExampleTest()
        {
            //Arrange
            var worldGenerator = new MarsGenerator();
            var startposition = new Position(1, 1);
            var startDirection = Direction.North;

            //Act
            var rover = new Rover(worldGenerator, startposition, startDirection);

            //Assert
            Assert.NotNull(rover);
        }
    }
}
