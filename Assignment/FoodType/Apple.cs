using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.FoodType
{
    public class Apple : Food
    {
        public Apple()
        {
            FoodAmount = 10;
            FoodPrice = 0.5;
        }
    }
}
