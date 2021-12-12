using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.MedicineType
{
    public class Potion : Medicine
    {
        public Potion()
        {
            MedicineAmount = 50;
            MedicinePrice = 4;
        }
    }
}
