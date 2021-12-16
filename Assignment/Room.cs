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
        public double PreferredTemperature { get; set; }
        public double RoomTemperature { get; set; } = 15;
        public double AmbientTemperature { get; set; }
        
        public Room(double preferredTemperature)
        {
            PreferredTemperature = preferredTemperature;
            AmbientTemperature = RoomTemperature;
        }

        public Room()
        {
            PreferredTemperature = RoomTemperature;
            AmbientTemperature = RoomTemperature;
        }

        public void SetPreferredTemperature(double preferredTemperature)
        {
            PreferredTemperature = preferredTemperature;
        }

        public void ChangeRoomTemperature()
        {
            while (true)
            {
                if (RoomTemperature < AmbientTemperature - 1)
                {

                    RoomTemperature += 1.5;
                }
                else if (RoomTemperature > AmbientTemperature + 1)
                {
                    RoomTemperature -= 1.5;
                }
                else
                {
                    RoomTemperature = AmbientTemperature;
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
