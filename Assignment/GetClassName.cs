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
        /// <summary>
        /// Return the name of the class without Namespace.Folder
        /// </summary>
        /// <param name="input">Class name as string</param>
        /// <returns>Returns name of class as string</returns>
        public static string Get(string input)
        {
            string convertedWord;

            string[] words = input.Split('.');

            string lastWord = words[^1];

            string[] splitWord = Regex.Split(lastWord, @"(?<!^)(?=[A-Z])");

            convertedWord = string.Join(" ", splitWord);

            return convertedWord;
        }

        /// <summary>
        /// Return the name of the class without Namespace.Folder
        /// </summary>
        /// <param name="input">Class Type</param>
        /// <returns>Returns name of class as string</returns>
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
