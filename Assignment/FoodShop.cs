using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment
{
    internal class FoodShop : Shop, IShop
    {
        public object Purchase(int windowTop)
        {
            object PurchasedItem = null;

            List<Food> AllFoods = GetDerivedClasses.GetClassesOfType<Food>();

            int position;

            do
            {
                ClearUnderPet.Clear(windowTop);

                Console.WriteLine($@"Coins: {Money}");

                int count = 1;

                foreach (Food food in AllFoods)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(food.GetType())} ({food.FoodPrice} coins)");

                    count++;
                }

                Console.Write(@"
Enter number of food wanting to purchase or -1 to exit: ");

                _ = int.TryParse(Console.ReadLine(), out position);

                if (position == 0 || position > AllFoods.Count)
                {

                }
                else if (position != -1)
                {
                    position--;

                    if (Money - AllFoods[position].FoodPrice < 0)
                    {
                        Console.WriteLine("Insufficient coins");
                        PurchasedItem = null;

                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Money -= AllFoods[position].FoodPrice;

                        PurchasedItem = AllFoods[position];
                    }
                }

            } while (PurchasedItem == null && position != -1);

            return PurchasedItem;
        }
    }
}
