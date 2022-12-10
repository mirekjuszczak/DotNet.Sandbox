using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Reactive.Net.Sandbox.Operators
{
    public class RetryOperator
    {
        public static void RunSample()
        {
            NonStableNumberObservable()
                .Retry()
                .Do(x=> Console.Write($"Correct number in [100, 120] after retry = {x}..."))
                .Subscribe(x => Console.WriteLine($" Emitting non stable value..."));
        }

        private static IObservable<int> NonStableNumberObservable() =>
            Observable.Create<int>(observer =>
            {
                var rnd = new Random();

                for(int i =0; i <5; i++)
                {
                    var randomNumber = rnd.Next(1, 120);

                    if (randomNumber < 100)
                    {
                        observer.OnError(new Exception("Wrong value!!!"));
                        return Disposable.Empty;
                    }

                    observer.OnNext(randomNumber); 
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}