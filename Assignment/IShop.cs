using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Ensures that all shops will have a purchase method
    /// </summary>
    internal interface IShop
    {
        object Purchase(int windowTop);
    }
}
