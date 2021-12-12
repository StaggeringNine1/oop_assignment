using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class SelectFood
    {
        public static Food Select(List<Food> FoodInventory, int windowTop)
        {
            Food selectedFood;
            int position;

            do
            {
                ClearUnderPet.Clear(windowTop);

                selectedFood = null;

                int count = 1;

                foreach (Food food in FoodInventory)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(food.GetType())} (Refills {food.FoodAmount} food)");
                    count++;
                }

                Console.Write($@"
Enter food number or -1 to exit: ");

                _ = int.TryParse(Console.ReadLine(), out position);

                if (position == 0 || position > FoodInventory.Count)
                {

                }
                else if (position != -1)
                {
                    selectedFood = FoodInventory[position - 1];
                }

            } while (selectedFood == null && position != -1);

            return selectedFood;
        }
    }
}
