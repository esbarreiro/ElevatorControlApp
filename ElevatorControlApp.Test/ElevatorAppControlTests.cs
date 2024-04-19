namespace ElevatorControlApp.Test
{
    [TestFixture]
    public class ElevatorAppControlTests
    {
        private ElevatorControlService elevatorControl;

        [SetUp]
        public void Setup()
        {
            elevatorControl = new ElevatorControlService();
        }

        [Test]
        public void SelectFloor_ValidFloor_ElevatorMovesToFloor()
        {
            elevatorControl.SelectFloor(3);
            Assert.That(elevatorControl.GetCurrentFloor(), Is.EqualTo(3));
        }

        [Test]
        public void HandleCallButton_ElevatorOnSameFloor_NoMovement()
        {
            elevatorControl.SelectFloor(2);
            elevatorControl.CallElevator(2);
            Assert.That(elevatorControl.GetCurrentFloor(), Is.EqualTo(2));
        }

        [Test]
        public void CallElevator_ElevatorMovesInCorrectDirection()
        {
            elevatorControl.SelectFloor(3);
            elevatorControl.CallElevator(5);
            Assert.That(elevatorControl.GetCurrentFloor(), Is.EqualTo(5));
        }

        [Test]
        public void CallElevator_ElevatorMovesToSpecifiedFloor()
        {
            elevatorControl.CallElevator(4);
            Assert.That(elevatorControl.GetCurrentFloor(), Is.EqualTo(4));
        }
    }
}