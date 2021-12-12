using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment
{
    internal class GetClassName
    {
        public static string Get(string input)
        {
            string convertedWord;

            string[] words = input.Split('.');

            string lastWord = words[^1];

            string[] splitWord = Regex.Split(lastWord, @"(?<!^)(?=[A-Z])");

            convertedWord = string.Join(" ", splitWord);

            return convertedWord;
        }

        public static string Get(Type input)
        {
            string convertedWord;

            string[] words = input.ToString().Split('.');

            string lastWord = words[^1];

            string[] splitWord = Regex.Split(lastWord, @"(?<!^)(?=[A-Z])");

            convertedWord = string.Join(" ", splitWord);

            return convertedWord;
        }
    }
}
