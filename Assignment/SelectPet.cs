using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.PetType;

namespace Assignment
{
    internal class SelectPet
    {
        public static object[] Select()
        {
            object[] LoadedItems = new object[5];

            Pet selectedPet;
            bool loadedPetFromFile = false;

            List<Pet> AllPets = GetDerivedClasses.GetClassesOfType<Pet>();

            do
            {
                int count = 1;

                Console.Clear();
                Console.WriteLine("Select type of pet:");

                foreach (Pet pet in AllPets)
                {
                    Console.WriteLine($@"{count}: {GetClassName.Get(pet.GetType())}");
                    count++;
                }

                Console.WriteLine($@"{count}: Load pet from file");

                Console.Write("Pet Number: ");

                _ = int.TryParse(Console.ReadLine(), out int index);

                if (index <= 0 || index > AllPets.Count + 2)
                {
                    selectedPet = null;
                }
                else if (index == AllPets.Count + 1)
                {
                    LoadedItems = LoadFromXML.LoadPet();
                    selectedPet = (Pet)LoadedItems[0];
                    loadedPetFromFile = true;
                }
                else
                {
                    selectedPet = AllPets[index - 1];
                    LoadedItems[0] = selectedPet;
                }

                if (selectedPet != null)
                {
                    bool passedCheck;

                    do
                    {
                        if (loadedPetFromFile)
                        {
                            passedCheck = true;
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine($@"You have selected a {GetClassName.Get(selectedPet.GetType())}. Is this okay? [Y/N]");

                            ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                            switch (consoleKey.Key)
                            {
                                case ConsoleKey.Y:
                                    passedCheck = true;
                                    break;

                                case ConsoleKey.N:
                                    passedCheck = true;
                                    selectedPet = null;
                                    break;

                                default:
                                    passedCheck = false;
                                    break;
                            }
                        }

                    } while (!passedCheck);

                }

            } while (selectedPet == null);

            return LoadedItems;
        }
    }
}
