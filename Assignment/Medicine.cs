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
    [XmlRoot("MedicineInventory")]
    public abstract class Medicine
    {
        [XmlAttribute("MedicineAmount")]
        public int MedicineAmount { get; set; }

        [XmlAttribute("MedicinePrice")]
        public double MedicinePrice { get; set; } // So child classes can set the price
    }
}
