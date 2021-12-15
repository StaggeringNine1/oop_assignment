using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class ClearStats
    {
        /// <summary>
        /// Clear console from underneath the pet, removing stats
        /// </summary>
        /// <param name="windowTop"></param>
        public static void Clear(int windowTop)
        {
            Console.SetCursorPosition(Console.WindowLeft, windowTop);

            for (int lineNumber = windowTop + 4; lineNumber < Console.WindowHeight; lineNumber++)
            {
                Console.SetCursorPosition(Console.WindowLeft, lineNumber);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(Console.WindowLeft, windowTop);
        }
    }
}
