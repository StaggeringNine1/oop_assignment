using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment
{
    internal class GetDerivedClasses
    {
        public static List<T> GetClassesOfType<T>() where T : class
        {
            List<T> classes = new();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                classes.Add((T)Activator.CreateInstance(type));
            }

            return classes;
        }
    }
}
