using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal interface IPetType
    {
        void Display();
        void Feed(Food food);
        void Play(Toy toy);
        void GiveMedicine(Medicine medicine);
    }
}
