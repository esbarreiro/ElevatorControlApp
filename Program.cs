namespace ElevatorControlApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to this elevator control! Where would you like to go?");
            Console.WriteLine("");
            Console.WriteLine("...................................");
            ElevatorControlService elevatorControl = new();

            while (true)
            {
                Console.WriteLine($"Elevator is currently at floor {elevatorControl.GetCurrentFloor()}");
                Console.WriteLine("");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Call elevator to a floor");
                Console.WriteLine("2. Inside elevator - Select floor");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CallElevator(elevatorControl);
                            break;
                        case 2:
                            InsideElevator(elevatorControl);
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                else
                {
                    InvalidInputResponse();
                }
            }
        }

        static void CallElevator(ElevatorControlService elevatorControl)
        {
            Console.WriteLine("Enter the floor to call the elevator:");
            if (int.TryParse(Console.ReadLine(), out int floor))
            {
                try
                {
                    ValidateFloor(floor);

                    elevatorControl.SelectFloor(floor);
                    ElevatorResponse(elevatorControl);
                }
                catch (Exception ex)
                {
                    ElevatorErrorResponse(ex);
                }
            }
            else
            {
                InvalidInputResponse();
            }
        }

        static void InsideElevator(ElevatorControlService elevatorControl)
        {
            Console.WriteLine("Enter the floor to move to:");
            if (int.TryParse(Console.ReadLine(), out int floor))
            {
                try
                {
                    ValidateFloor(floor);

                    elevatorControl.SelectFloor(floor);
                    ElevatorResponse(elevatorControl);


                }
                catch (Exception ex)
                {
                    ElevatorErrorResponse(ex);
                }
            }
            else
            {
                InvalidInputResponse();
            }
        }

        static void ValidateFloor(int floor)
        {
            if (floor < 1 || floor > 5)
            {
                throw new Exception("invalid floor selection");
            }
        }

        static void ElevatorErrorResponse(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("");
        }

        static void ElevatorResponse(ElevatorControlService elevatorControl)
        {
            Console.WriteLine($"Ding Dong! Elevator has arrived at floor {elevatorControl.GetCurrentFloor()}");
            Console.WriteLine("");
        }

        static void InvalidInputResponse()
        {
            Console.WriteLine("Invalid input");
            Console.WriteLine("");
        }
    }
}