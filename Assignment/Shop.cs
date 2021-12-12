using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment
{
    public abstract class Shop
    {
        public static double Money { get; set; } = 30;

        public static void IncreaseMoney()
        {
            while (true)
            {
                Money += 5;
                Thread.Sleep(5000);
            }
        }
    }
}
