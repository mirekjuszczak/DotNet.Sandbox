using System;

namespace DelegatesPlays.FuncActionSamples
{
    public class DelegateBasicSample
    {
        public delegate bool FuncOnStringTest(string str);

        public static void RunSample()
        {
            var s1 = "Abcdefgh";
            var s2 = "abc";

            var playsOnString = new MethodForDelegate();

            FuncOnStringTest test = playsOnString.LengthMoreThanFive;
            Console.WriteLine($"LengthMoreThanFive on {s1}: value {test(s1)}");
            Console.WriteLine($"LengthMoreThanFive on {s2}: value {test(s2)}");

            Console.WriteLine();
            test = playsOnString.LengthLessOrEqualFive;
            Console.WriteLine($"LengthMoreThanFive on {s1}: value {test(s1)}");
            Console.WriteLine($"LengthMoreThanFive on {s2}: value {test(s2)}");
        }
    }
    
    public class MethodForDelegate
    {
        public bool LengthMoreThanFive(string str) => str.Length > 5;
        public bool LengthLessOrEqualFive(string str) => str.Length <= 5;
    }
}