using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlApp
{
    public class ElevatorControlService
    {
        public int CurrentFloor { get; set; }
        public Direction ElevatorDirection { get; set; }
        public bool ElevatorDoorOpen { get; set; }

        private SortedSet<int> ElevatorRequestUp;
        private SortedSet<int> ElevatorRequestDown;

        public ElevatorControlService()
        {
            ElevatorDirection = Direction.NotMoving;
            CurrentFloor = 1;
            ElevatorDoorOpen = false;
            ElevatorRequestDown = new SortedSet<int>();
            ElevatorRequestUp = new SortedSet<int>();
        }

        public void CallElevator(int floor)
        {
            Direction elevatorDirection = floor > CurrentFloor ? Direction.Up : Direction.Down;

            if (elevatorDirection == Direction.Up)
                ElevatorRequestUp.Add(floor);
            else
                ElevatorRequestDown.Add(floor);

            MoveElevator();
        }

        private void MoveElevator()
        {
            while (ElevatorRequestUp.Count > 0 || ElevatorRequestDown.Count > 0)
            {
                if (ElevatorDirection == Direction.Up || ElevatorDirection == Direction.NotMoving)
                {
                    if (ElevatorRequestUp.Count > 0)
                    {
                        int nextFloor = ElevatorRequestUp.Min;
                        ElevatorRequestUp.Remove(nextFloor);

                        // this basically simulates that the elevator is going to the next floor
                        CurrentFloor = nextFloor;
                    }
                    else if (ElevatorRequestDown.Count > 0)
                    {
                        ElevatorDirection = Direction.Down;
                    }
                }
                else if (ElevatorDirection == Direction.Down)
                {
                    if (ElevatorRequestDown.Count > 0)
                    {
                        int nextFloor = ElevatorRequestDown.Max;
                        ElevatorRequestDown.Remove(nextFloor);
                        // Simulate moving to the next floor
                        CurrentFloor = nextFloor;
                    }
                    else if (ElevatorRequestUp.Count > 0)
                    {
                        ElevatorDirection = Direction.Up;
                    }
                }

                // Simulate opening doors
                ElevatorDoorOpen = true;
                // Simulate waiting for passengers to enter/exit
                ElevatorDoorOpen = false;

                // If no more requests, hold elevator
                if (ElevatorRequestUp.Count == 0 && ElevatorRequestDown.Count == 0)
                    ElevatorDirection = Direction.NotMoving;
            }
        }
        

        public void SelectFloor(int floor)
        {
            if (floor > CurrentFloor)
                ElevatorRequestUp.Add(floor);
            else if (floor < CurrentFloor)
                ElevatorRequestDown.Add(floor);

            MoveElevator();
        }

        public int GetCurrentFloor()
        {
            return CurrentFloor;
        }


    }
}
