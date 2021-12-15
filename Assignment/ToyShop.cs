using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Inherits both IShop and Shop to ensure existence of Purchase() and to access static Money
    /// </summary>
    internal class ToyShop : Shop, IShop
    {
        public object Purchase(int windowTop)
        {
            object PurchasedItem = null;

            List<Toy> AllToys = GetDerivedClasses.GetClassesOfType<Toy>();

            int position;

            do
            {
                ClearUnderPet.Clear(windowTop);

                Console.WriteLine($@"Coins: {Money}");

                int count = 1;

                foreach (Toy toy in AllToys)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(toy.GetType())} ({toy.ToyPrice} coins)");

                    count++;
                }

                Console.Write(@"
Enter number of toy wanting to purchase or -1 to exit: ");

                _ = int.TryParse(Console.ReadLine(), out position);

                if (position == 0 || position > AllToys.Count)
                {

                }
                else if (position != -1)
                {
                    position--;

                    if (Money - AllToys[position].ToyPrice < 0)
                    {
                        Console.WriteLine("Insufficient coins");
                        PurchasedItem = null;

                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Money -= AllToys[position].ToyPrice;

                        PurchasedItem = AllToys[position];
                    }
                }

            } while (PurchasedItem == null && position != -1);

            return PurchasedItem;
        }
    }
}
