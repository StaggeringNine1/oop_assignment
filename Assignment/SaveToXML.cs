using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Assignment.PetType;
using Assignment.FoodType;
using Assignment.MedicineType;
using Assignment.ToyType;

namespace Assignment
{
    internal class SaveToXML
    {
        public static void Save(Pet pet, double coins, List<Toy> toyInventory, List<Food> foodInventory, List<Medicine> medicineInventory)
        {
            string path = @"petFile.xml";

            XmlSerializer serializer = new(typeof(Pet), new Type[] { typeof(Dog), typeof(Cat), typeof(Apple), typeof(FoodPellet), typeof(Meat), typeof(Potato) });

            using var writer = new StreamWriter(path);
            serializer.Serialize(writer, pet);

            path = @"foodInventory.xml";
            serializer = new(typeof(List<Food>), new Type[] { typeof(Apple), typeof(FoodPellet), typeof(Meat), typeof(Potato) });

            using var foodWriter = new StreamWriter(path);
            serializer.Serialize(foodWriter, foodInventory);

            path = @"medicineInventory.xml";
            serializer = new(typeof(List<Medicine>), new Type[] { typeof(Bandage), typeof(Painkiller), typeof(Potion) });

            using var medicineWriter = new StreamWriter(path);
            serializer.Serialize(medicineWriter, medicineInventory);

            path = @"toyInventory.xml";
            serializer = new(typeof(List<Toy>), new Type[] { typeof(Ball), typeof(Energizer), typeof(Rope) });

            using var toyWriter = new StreamWriter(path);
            serializer.Serialize(toyWriter, toyInventory);

            path = @"money.xml";
            serializer = new(typeof(double));

            using var shopWriter = new StreamWriter(path);
            serializer.Serialize(shopWriter, coins);
        }
    }
}
