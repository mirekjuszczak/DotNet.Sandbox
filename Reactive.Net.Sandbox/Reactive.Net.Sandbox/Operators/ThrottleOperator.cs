using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Reactive.Net.Sandbox.Operators
{
    public class ThrottleOperator
    {
        public static void RunSample()
        {
            var throttleTimeInMs = 500;
            
            RandomNumberObservable()
                .Throttle(TimeSpan.FromMilliseconds(throttleTimeInMs))
                .Timestamp()
                .Subscribe(x => Console.WriteLine($"Next number {x.Value} on Timestamp {x.Timestamp}, Throttle time set to {throttleTimeInMs}ms..."));
        }

        private static IObservable<int> RandomNumberObservable() =>
            Observable.Create<int>(observer =>
            {
                var rnd = new Random();

                while (true)
                {
                    var keypress = Console.ReadKey();
                    if (keypress.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    var number = rnd.Next(10, 200);
                    observer.OnNext(number);
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}