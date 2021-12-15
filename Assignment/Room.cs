using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    public class Room
    {
        public double PreferredTemperature { get; private set; }
        public double RoomTemperature { get; private set; } = 15;

        public Room(double preferredTemperature)
        {
            PreferredTemperature = preferredTemperature;
        }

        public void SetPreferredTemperature(double preferredTemperature)
        {
            PreferredTemperature = preferredTemperature;
        }

        public void ChangeRoomTemperature()
        {
            Random random = new();

            while (true)
            {
                int randomNumber = random.Next(1, 2);

                if (randomNumber == 1)
                {
                    RoomTemperature += 0.25 * random.Next(1, 3);
                }
                else
                {
                    RoomTemperature -= 0.25 * random.Next(1, 3);
                }

                Thread.Sleep(3000);
            }
        }

        public void IncreaseRoomTemperature()
        {
            RoomTemperature += 0.5;
        }

        public void DecreaseRoomTemperature()
        {
            RoomTemperature -= 0.5;
        }
    }
}
