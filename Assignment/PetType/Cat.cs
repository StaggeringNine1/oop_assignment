using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.PetType
{
    [XmlRoot("SavedPet")]
    public class Cat : Pet
    {
        public Food MostRecentFood { get; set; }

        private int FoodToEat { get; set; }

        public Cat()
        {
            MaxFood = 75;
            CurrentFood = MaxFood;

            MaxHealth = 75;
            CurrentHealth = MaxHealth;

            MaxPlay = 75;
            CurrentPlay = MaxPlay;

            room.SetPreferredTemperature(19);
        }

        public override void Display()
        {
            Console.WriteLine(@"
 /\     /\
{  `---'  }
{  O   O  }
~~>  V  <~~
 \  \|/  /
  `-----'__
  /     \  `^\_
 {       }\ |\_\_   W
 |  \_/  |/ /  \_\_( )
  \__/  /(_E     \__/
    (  /
     MM"
);
        }

        public override void Feed(Food food)
        {
            int amountToFeed = food.FoodAmount;

            if (MostRecentFood != null)
            {
                if (food.GetType() == MostRecentFood.GetType())
                {
                    amountToFeed /= 2;
                }
            }

            FoodToEat = amountToFeed;

            MostRecentFood = food;
        }

        public override void DecreaseFood()
        {
            while (true)
            {
                if (FoodToEat > 0)
                {
                    if (FoodToEat - 5 > MaxFood)
                    {
                        CurrentFood = MaxFood;
                    }
                    else
                    {
                        CurrentFood += 5;
                    }

                    FoodToEat -= 5;
                }
                else
                {
                    if (CurrentFood - 5 < 0)
                    {
                        CurrentFood = 0;
                    }
                    else
                    {
                        CurrentFood -= 5;
                    }
                }
                

                Thread.Sleep(1500);
            }
        }

        public override void Play(Toy toy)
        {
            if (CurrentPlay + toy.PlayAmount >= MaxPlay)
            {
                CurrentPlay = MaxPlay;
            }
            else
            {
                CurrentPlay += toy.PlayAmount;
            }
        }

        public override void GiveMedicine(Medicine medicine)
        {
            if (CurrentHealth + medicine.MedicineAmount >= MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += medicine.MedicineAmount;
            }

            int amountToFeed = medicine.MedicineAmount / 2;

            if (CurrentFood + amountToFeed >= MaxFood)
            {
                CurrentFood = MaxFood;
            }
            else
            {
                CurrentFood += amountToFeed;
            }
        }
    }
}
