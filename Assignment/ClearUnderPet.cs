using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class ClearUnderPet
    {
        public static void Clear(int windowTop)
        {
            Console.SetCursorPosition(Console.WindowLeft, windowTop + 5);

            for (int lineNumber = windowTop + 4; lineNumber < Console.WindowHeight; lineNumber++)
            {
                Console.SetCursorPosition(Console.WindowLeft, lineNumber);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(Console.WindowLeft, windowTop + 6);
        }
    }
}
