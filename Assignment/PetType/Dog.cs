using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.PetType
{
    [XmlRoot("SavedPet")]
    public class Dog : Pet
    {
        public Dog()
        {
            MaxFood = 100;
            CurrentFood = MaxFood;

            MaxHealth = 100;
            CurrentHealth = MaxHealth;

            MaxPlay = 100;
            CurrentPlay = MaxPlay;

            PreferredTemperature = 20;
        }

        public override void Display()
        {
            Console.WriteLine(@"
  ,_-~~~-,    _-~~-_
 /        ^-_/      \_    _-~-.
|      /\  ,          `-_/     \
|   /~^\ '/  /~\  /~\   / \_    \
 \_/    }/  /        \  \ ,_\    }
        Y  /  /~  /~  |  Y   \   |
       /   | {Q) {Q)  |  |    \_/
       |   \  _===_  /   |
       /  >--{     }--<  \
     /~       \_._/       ~\
    /    *  *   Y    *      \
    |      * .: | :.*  *    |
    \    )--__==#==__--     /
     \_      \  \  \      ,/
       '~_    | |  }   ,~'
          \   {___/   /
           \   ~~~   /
           /\._._._./\
          {    ^^^    }
           ~-_______-~
            /       \"
);
        }

        public override void Feed(Food food)
        {
            if (CurrentFood + food.FoodAmount >= MaxFood)
            {
                CurrentFood = MaxFood;
            }
            else
            {
                CurrentFood += food.FoodAmount;
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
        }
    }
}
