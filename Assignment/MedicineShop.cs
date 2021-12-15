using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment
{
    /// <summary>
    /// Inherits both IShop and Shop to ensure existence of Purchase() and to access static Money
    /// </summary>
    internal class MedicineShop : Shop, IShop
    {
        public object Purchase(int windowTop)
        {
            object PurchasedItem = null;

            List<Medicine> AllMedicine = GetDerivedClasses.GetClassesOfType<Medicine>();

            int position;

            do
            {
                ClearUnderPet.Clear(windowTop);

                Console.WriteLine($@"Coins: {Money}");

                int count = 1;

                foreach (Medicine medicine in AllMedicine)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(medicine.GetType())} ({medicine.MedicinePrice} coins)");

                    count++;
                }

                Console.Write(@"
Enter number of medicine wanting to purchase or -1 to exit: ");

                _ = int.TryParse(Console.ReadLine(), out position);

                if (position == 0 || position > AllMedicine.Count)
                {

                }
                else if (position != -1)
                {
                    position--;

                    if (Money - AllMedicine[position].MedicinePrice < 0)
                    {
                        Console.WriteLine("Insufficient coins");
                        PurchasedItem = null;

                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Money -= AllMedicine[position].MedicinePrice;

                        PurchasedItem = AllMedicine[position];
                    }
                }

            } while (PurchasedItem == null && position != -1);

            return PurchasedItem;
        }
    }
}
