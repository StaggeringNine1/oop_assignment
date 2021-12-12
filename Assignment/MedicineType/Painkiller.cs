using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.MedicineType
{
    public class Painkiller : Medicine
    {
        public Painkiller()
        {
            MedicineAmount = 20;
            MedicinePrice = 2.5;
        }
    }
}
