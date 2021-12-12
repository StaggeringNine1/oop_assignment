using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class SelectToy
    {
        public static Toy Select(List<Toy> ToyInventory, int windowTop)
        {
            Toy selectedFood;
            int position;

            do
            {
                ClearUnderPet.Clear(windowTop);

                selectedFood = null;

                int count = 1;

                foreach (Toy toy in ToyInventory)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(toy.GetType())} (Refills {toy.PlayAmount} happiness)");
                    count++;
                }

                Console.Write($@"
Enter food number or -1 to exit: ");

                _ = int.TryParse(Console.ReadLine(), out position);

                if (position == 0 || position > ToyInventory.Count)
                {

                }
                else if (position != -1)
                {
                    selectedFood = ToyInventory[position - 1];
                }

            } while (selectedFood == null && position != -1);

            return selectedFood;
        }
    }
}
