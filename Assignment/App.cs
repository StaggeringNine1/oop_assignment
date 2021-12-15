using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;


namespace Assignment
{
    internal class App
    {
        private Pet pet;

        private readonly ToyShop toyShop = new();
        private readonly FoodShop foodShop = new();
        private readonly MedicineShop medicineShop = new();

        private bool RunDisplayThread = true;
        private bool PetDisplayed;

        private int windowTop = -1;

        private int totalHealthBlocks;
        private int totalPlayBlocks;
        private int totalFoodBlocks;

        private List<Food> FoodInventory = new();
        private List<Toy> ToyInventory = new();
        private List<Medicine> MedicineInventory = new();

        private Thread hungerThread;
        private Thread boredomThread;
        private Thread healthThread;
        private Thread roomTemperatureThread;
        private Thread moneyThread;

        private void DisplayStats()
        {
            while (true)
            {
                if (RunDisplayThread)
                {
                    if (!PetDisplayed)
                    {
                        Console.WriteLine(pet.PetName);

                        pet.Display();
                        Console.WriteLine();

                        PetDisplayed = true;
                    }

                    if (windowTop == -1)
                    {
                        Console.SetCursorPosition(Console.WindowLeft, Console.GetCursorPosition().Top);
                        windowTop = Console.GetCursorPosition().Top;

                    }
                    else
                    {
                        Console.SetCursorPosition(Console.WindowLeft, windowTop);
                    }

                    if (pet.CurrentHealth <= 0)
                    {
                        Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);

                        for (int lineNumber = Console.GetCursorPosition().Top; lineNumber <= Console.WindowHeight; lineNumber++)
                        {
                            Console.SetCursorPosition(Console.WindowLeft, lineNumber);
                            Console.Write(new string(' ', Console.WindowWidth));
                        }

                        Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);

                        Console.WriteLine($@"
        _.---,._,'
       /' _.--.<
         /'     `'
       /' _.---._____
       \.'   ___, .-'`
           /'    \\             .
         /'       `-.          -|-
        |                       |
        |                   .-'~~~`-.
        |                 .'         `.
        |                 |  R  I  P  |
        |                 |           |
        |                 |           |
         \              \\|           |//
   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");

                        Console.WriteLine($@"{pet.PetName} has died");
                    }
                    else
                    {
                        int healthBlocks = pet.CurrentHealth * 10 / pet.MaxHealth;
                        int playBlocks = pet.CurrentPlay * 10 / pet.MaxPlay;
                        int foodBlocks = pet.CurrentFood * 10 / pet.MaxFood;

                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(Console.WindowLeft, Console.GetCursorPosition().Top);
                        Console.Write("Health Level: [");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(new string('█', healthBlocks));
                        Console.Write(new string(' ', totalHealthBlocks - healthBlocks));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("]");

                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(Console.WindowLeft, Console.GetCursorPosition().Top);
                        Console.Write("Happiness Level: [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(new string('█', playBlocks));
                        Console.Write(new string(' ', totalPlayBlocks - playBlocks));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("]");

                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(Console.WindowLeft, Console.GetCursorPosition().Top);
                        Console.Write("Food Level: [");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(new string('█', foodBlocks));
                        Console.Write(new string(' ', totalFoodBlocks - foodBlocks));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("]");

                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(Console.WindowLeft, Console.GetCursorPosition().Top);
                        Console.WriteLine($@"Preferred Temperature: {pet.room.PreferredTemperature}°C");
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(Console.WindowLeft, Console.GetCursorPosition().Top);
                        Console.WriteLine($@"Room Temperature: {pet.room.RoomTemperature}°C");
                    }
                }

                Thread.Sleep(10);
            }
        }

        public void Run()
        {
            object[] LoadedObjects = SelectPet.Select();

            pet = (Pet)LoadedObjects[0];

            if (LoadedObjects[1] != null)
            {
                FoodInventory = (List<Food>)LoadedObjects[1];
            }

            if (LoadedObjects[2] != null)
            {
                MedicineInventory = (List<Medicine>)LoadedObjects[2];
            }

            if (LoadedObjects[3] != null)
            {
                ToyInventory = (List<Toy>)LoadedObjects[3];
            }

            if (LoadedObjects[4] != null)
            {
                Shop.Money = (double)LoadedObjects[4];
            }

            Console.Clear();

            if (pet.PetName is null)
            {
                Console.Write("Enter pet name: ");
                pet.PetName = Console.ReadLine();
            }

            totalHealthBlocks = pet.MaxHealth * 10 / pet.MaxHealth;
            totalPlayBlocks = pet.MaxPlay * 10 / pet.MaxPlay;
            totalFoodBlocks = pet.MaxFood * 10 / pet.MaxFood;

            hungerThread = new(pet.DecreaseFood);
            boredomThread = new(pet.DecreasePlay);
            healthThread = new(pet.DecreaseHealth);
            roomTemperatureThread = new(pet.room.ChangeRoomTemperature);
            moneyThread = new(Shop.IncreaseMoney);

            hungerThread.Start();
            boredomThread.Start();
            healthThread.Start();
            roomTemperatureThread.Start();
            moneyThread.Start();

            Console.CursorVisible = false;

            Console.Clear();

            Console.WriteLine($@"Pet Name: {pet.PetName}");

            pet.Display();
            PetDisplayed = true;

            Console.WriteLine();

            Thread displayThread = new(DisplayStats);

            displayThread.Start();

            Thread.Sleep(10);

            do
            {
                RunDisplayThread = false;
                Console.SetCursorPosition(Console.WindowLeft, windowTop + 5);

                for (int lineNumber = Console.GetCursorPosition().Top; lineNumber <= Console.WindowHeight; lineNumber++)
                {
                    Console.SetCursorPosition(Console.WindowLeft, lineNumber);
                    Console.Write(new string(' ', Console.WindowWidth));
                }

                Console.SetCursorPosition(Console.WindowLeft, windowTop + 6);

                Console.WriteLine($@"Controls:
1. Feed pet
2. Heal pet
3. Play with pet
4. Shop
5. Raise room temperature by 0.5°C
6. Lower room temperature by 0.5°C
7. Save pet to XML file");

                RunDisplayThread = true;

                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        RunDisplayThread = false;

                        Food selectedFood = SelectFood.Select(FoodInventory, windowTop);

                        if (selectedFood != null)
                        {
                            pet.Feed(selectedFood);
                            FoodInventory.Remove(selectedFood);
                        }

                        ClearStats.Clear(windowTop);

                        RunDisplayThread = true;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        RunDisplayThread = false;

                        Medicine selectedMedicine = SelectMedicine.Select(MedicineInventory, windowTop);

                        if (selectedMedicine != null)
                        {
                            pet.GiveMedicine(selectedMedicine);
                            MedicineInventory.Remove(selectedMedicine);
                        }

                        ClearStats.Clear(windowTop);

                        RunDisplayThread = true;
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        RunDisplayThread = false;

                        Toy selectedToy = SelectToy.Select(ToyInventory, windowTop);

                        if (selectedToy != null)
                        {
                            pet.Play(selectedToy);
                            ToyInventory.Remove(selectedToy);
                        }

                        ClearStats.Clear(windowTop);

                        RunDisplayThread = true;
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        RunDisplayThread = false;
                        bool purchasedItem = false;

                        do
                        {
                            ClearUnderPet.Clear(windowTop);

                            Console.WriteLine($@"
1. Food Shop
2. Toy Shop
3. Medicine Shop");

                            ConsoleKeyInfo consoleKey1 = Console.ReadKey(true);

                            switch (consoleKey1.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Food purchasedFood = (Food)foodShop.Purchase(windowTop);

                                    if (purchasedFood != null)
                                    {
                                        FoodInventory.Add(purchasedFood);
                                    }

                                    purchasedItem = true;
                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Toy purchasedToy = (Toy)toyShop.Purchase(windowTop);

                                    if (purchasedToy != null)
                                    {
                                        ToyInventory.Add(purchasedToy);
                                    }

                                    purchasedItem = true;
                                    break;

                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    Medicine purchasedMedicine = (Medicine)medicineShop.Purchase(windowTop);

                                    if (purchasedMedicine != null)
                                    {
                                        MedicineInventory.Add(purchasedMedicine);
                                    }

                                    purchasedItem = true;
                                    break;
                            }

                        } while (!purchasedItem);

                        RunDisplayThread = true;
                        break;

                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        pet.room.IncreaseRoomTemperature();
                        break;

                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        pet.room.DecreaseRoomTemperature();
                        break;

                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        SaveToXML.Save(pet, Shop.Money, ToyInventory, FoodInventory, MedicineInventory);
                        break;

                }

            } while (true);
        }
    }
}
