using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.ToyType
{
    public class Energizer : Toy
    {
        public Energizer()
        {
            PlayAmount = 60;
            ToyPrice = 5;
        }
    }
}
