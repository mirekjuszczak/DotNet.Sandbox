using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Reactive.Net.Sandbox.Operators
{
    public class RepeatOperator
    {
        public static void RunRangeSample()
        {
            var counter = 3;

            Observable
                .Range(1, 3)
                .Repeat(counter)
                .Subscribe(x => Console.WriteLine($"Number {x} repeated {counter} times"));
        }

        public static void RunNumberObservableSample()
        {
            var counter = 3;
            
            NumberObservable()
                .Repeat(counter)
                .Subscribe(x => Console.WriteLine($"Number {x} repeated {counter} times"));
        }

        private static IObservable<int> NumberObservable() =>
            Observable.Create<int>(observer =>
            {
                var rnd = new Random();

                for(int i =0; i <3; i++)
                {
                    observer.OnNext(rnd.Next(1, 20));
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}