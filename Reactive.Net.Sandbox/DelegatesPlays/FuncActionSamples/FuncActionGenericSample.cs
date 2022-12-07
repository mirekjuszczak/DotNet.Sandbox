using System;
using System.Collections.Generic;

namespace DelegatesPlays.FuncActionSamples
{
    public class FuncActionGenericSample
    {
        public static void RunSample()
        {
            List<string> collection = new List<string>() { "aa", "bbb", "cccc", "ddddd", "eeeeee", "fffffff", "gggggggg" };
            ForEachElement(collection, LengthIsEvenNumber, Print);
        }

        public static void ForEachElement<T>(IEnumerable<T> collection, Func<T, bool> predicate, Action<T> action)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    action(item);
                }
            }
        }

        public static bool LengthIsEvenNumber(string str) => str.Length % 2 == 0;

        private static void Print(string str)
        {
            Console.WriteLine($"Next even number {str}");
        }
    }
}