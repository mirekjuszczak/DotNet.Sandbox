using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Operators
{
    public class ThrottleOperatorWithSubject
    {
        public static void RunSample()
        {
            var throttleTimeInMs = 500;

            var subject = RandomNumberObservable();

            subject
                .Throttle(TimeSpan.FromMilliseconds(throttleTimeInMs))
                .Timestamp()
                .Subscribe(x =>
                    Console.WriteLine(
                        $"Next number {x.Value} on Timestamp {x.Timestamp}, Throttle time set to {throttleTimeInMs}ms..."));
        }

        private static IObservable<int> RandomNumberObservable()
        {
            var subject = new Subject<int>();
            var rnd = new Random();

            while (true)
            {
                var keypress = Console.ReadKey();
                if (keypress.Key == ConsoleKey.Enter) 
                {
                    break;
                }

                var number = rnd.Next(10, 200);
                subject.OnNext(number);
            }

            subject.OnCompleted();
            return subject;
        }
    }
}