using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment.ToyType
{
    public class Rope : Toy
    {
        public Rope()
        {
            PlayAmount = 10;
            ToyPrice = 1;
        }
    }
}
