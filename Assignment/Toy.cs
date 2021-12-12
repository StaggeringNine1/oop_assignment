using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment
{
    [Serializable()]
    [XmlRoot("ToyInventory")]
    public abstract class Toy
    {
        [XmlAttribute("PlayAmount")]
        public int PlayAmount { get; set; }

        [XmlAttribute("ToyPrice")]
        public double ToyPrice { get; set; } // So child classes can set the price
    }
}
