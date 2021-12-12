using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment
{
    [Serializable]
    [XmlRoot("FoodInventory")]
    public abstract class Food
    {
        [XmlAttribute("FoodAmount")]
        public int FoodAmount { get; set; }

        [XmlAttribute("FoodPrice")]
        public double FoodPrice { get; set; } // So child classes can set the price
    }
}
