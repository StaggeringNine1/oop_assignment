using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Assignment.PetType;
using Assignment.FoodType;
using Assignment.MedicineType;
using Assignment.ToyType;

namespace Assignment
{
    internal class LoadFromXML
    {

        /// <summary>
        /// Return the loaded pet data if any
        /// </summary>
        /// <returns>Retursn object[5], [0] being Pet, 
        /// [1] being foodInventory 
        /// [2] being medicineInventory
        /// [3] being toyInventory
        /// [4] being money
        /// </returns>
        public static object[] LoadPet()
        {
            object[] ReturnObjects = new object[5];

            Pet pet = null;

            string path = @"petFile.xml";

            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(Pet), new Type[] { typeof(Cat), typeof(Dog), typeof(Apple), typeof(FoodPellet), typeof(Meat), typeof(Potato) });

                using var reader = new StreamReader(path);
                try
                {
                    pet = (Pet)serializer.Deserialize(reader);
                }
                catch
                {
                    Console.WriteLine("Could not load pet");
                }
            }

            ReturnObjects[0] = pet;

            List<Food> foodInventory = new();

            path = @"foodInventory.xml";

            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(List<Food>), new Type[] { typeof(Apple), typeof(FoodPellet), typeof(Meat), typeof(Potato) });

                using var reader = new StreamReader(path);
                try
                {
                    foodInventory = (List<Food>)serializer.Deserialize(reader);
                }
                catch
                {
                    Console.WriteLine("Could not load food inventory");
                }
            }

            ReturnObjects[1] = foodInventory;

            List<Medicine> medicineInventory = new();

            path = @"medicineInventory.xml";

            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(List<Medicine>), new Type[] { typeof(Bandage), typeof(Painkiller), typeof(Potion) });

                using var reader = new StreamReader(path);
                try
                {
                    medicineInventory = (List<Medicine>)serializer.Deserialize(reader);
                }
                catch
                {
                    Console.WriteLine("Could not load medicine inventory");
                }
            }

            ReturnObjects[2] = medicineInventory;

            List<Toy> toyInventory = new();

            path = @"toyInventory.xml";

            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(List<Toy>), new Type[] { typeof(Ball), typeof(Rope), typeof(Energizer) });

                using var reader = new StreamReader(path);
                
                try
                {
                    toyInventory = (List<Toy>)serializer.Deserialize(reader);
                }
                catch
                {
                    Console.WriteLine("Could not load toy inventory");
                }
            }

            ReturnObjects[3] = toyInventory;

            double money = 0;

            path = @"money.xml";

            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(double));

                using var reader = new StreamReader(path);

                try
                {
                    money = (double)serializer.Deserialize(reader);
                }
                catch
                {
                    Console.WriteLine("Could not load money");
                }
            }

            ReturnObjects[4] = money;

            return ReturnObjects;
        }
    }
}
