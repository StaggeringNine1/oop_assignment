using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.FoodType
{
    public class Meat : Food
    {
        public Meat()
        {
            FoodAmount = 50;
            FoodPrice = 3;
        }
    }
}
