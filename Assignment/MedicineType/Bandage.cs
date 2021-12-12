using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace Assignment.MedicineType
{
    public class Bandage : Medicine
    {
        public Bandage()
        {
            MedicineAmount = 10;
            MedicinePrice = 1.5;
        }
    }
}
