using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.FoodType
{ 
    public class Potato : Food
    {
        public Potato()
        {
            FoodAmount = 20;
            FoodPrice = 1.5;
        }
    }
}
