using System;
using System.Linq;

namespace Reactive.Net.Sandbox.OtherSamples
{
    public class ElementIndexFromCollection
    {
        public static void RunSample()
        {
            var collection = new int[] { 1, 0, 5, 0, 0, 3, 0, 3, 2, 0, 0, };
            
            var result = collection
                .Select((value, ind) => new { value, ind })
                .Where(value => value.value == 0)
                .Select(arg => arg.ind)
                .ToArray();
            
            Console.WriteLine();
        }
    }
}