using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment
{
    [Serializable()]
    [XmlRoot("SavedPet")]
    public abstract class Pet : IPetType
    {
        [XmlAttribute("CurrentFood")]
        public int CurrentFood { get; set; }

        [XmlAttribute("MaxFood")]
        public int MaxFood { get; set; }

        [XmlAttribute("CurrentPlay")]
        public int CurrentPlay { get; set; }

        [XmlAttribute("MaxPlay")]
        public int MaxPlay { get; set; }

        [XmlAttribute("CurrentHealth")]
        public int CurrentHealth { get; set; }

        [XmlAttribute("MaxHealth")]
        public int MaxHealth { get; set; }

        [XmlAttribute("PetName")]
        public string PetName { get; set; } = null;

        public Room room = new(1);

        public virtual void Display()
        {

        }

        public virtual void Feed(Food food)
        {

        }

        public virtual void GiveMedicine(Medicine medicine)
        {

        }

        public virtual void Play(Toy toy)
        {

        }

        public virtual void DecreaseFood()
        {
            while (true)
            {
                if (CurrentFood - 5 < 0)
                {
                    CurrentFood = 0;
                }
                else
                {
                    CurrentFood -= 5;
                }

                Thread.Sleep(1500);
            }
        }

        public virtual void DecreasePlay()
        {
            while (true)
            {
                if (CurrentPlay - 5 < 0)
                {
                    CurrentPlay = 0;
                }
                else
                {
                    CurrentPlay -= 5;
                }

                Thread.Sleep(1000);
            }
        }

        public virtual void DecreaseHealth()
        {
            while (true)
            {
                if (CurrentFood < MaxFood / 2)
                {
                    if (CurrentHealth - 5 < 0)
                    {
                        CurrentHealth = 0;
                    }
                    else
                    {
                        CurrentHealth -= 5;
                    }
                }

                if (room.RoomTemperature < room.PreferredTemperature - 2 || room.RoomTemperature > room.PreferredTemperature + 2)
                {
                    if (CurrentHealth - 2 < 0)
                    {
                        CurrentHealth = 0;
                    }
                    else
                    {
                        CurrentHealth -= 2;
                    }
                }

                Thread.Sleep(2000);
            }
        }
    }
}
