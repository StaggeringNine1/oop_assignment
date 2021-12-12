using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class SelectMedicine
    {
        public static Medicine Select(List<Medicine> MedicineInventory, int windowTop)
        {
            Medicine selectedMedicine;
            int position;

            do
            {
                ClearUnderPet.Clear(windowTop);

                selectedMedicine = null;

                int count = 1;

                foreach (Medicine medicine in MedicineInventory)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(medicine.GetType())} (Refills {medicine.MedicineAmount} health)");
                    count++;
                }

                Console.Write($@"
Enter food number or -1 to exit: ");

                _ = int.TryParse(Console.ReadLine(), out position);

                if (position == 0 || position > MedicineInventory.Count)
                {

                }
                else if (position != -1)
                {
                    selectedMedicine = MedicineInventory[position - 1];
                }

            } while (selectedMedicine == null && position != -1);

            return selectedMedicine;
        }
    }
}
