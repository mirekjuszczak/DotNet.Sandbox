using System;
using System.Reactive.Linq;
using Console = System.Console;

namespace Reactive.Net.Sandbox.Operators
{
    public class TakeWhileSkipWhileOpertors
    {
        public static void RunSample()
        {
            var trials = 10;
            var start = 3;
            var stop = 7;
            
            Console.WriteLine($"Number of trials: {trials}");
            Console.WriteLine();
            
            Observable.Range(1, trials)
                .SkipWhile(x => x < start)
                .TakeWhile(x => x < stop)
                .Subscribe(x => Console.WriteLine($"Number in the range <{start}, {stop}) -> {x}"));
        }
    }
}