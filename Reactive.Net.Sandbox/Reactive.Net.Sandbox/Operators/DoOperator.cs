using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Operators
{
    public class DoOperator
    {
        public static void RunSample()
        {
            KeyPressObservable()
                .Do(c => Console.WriteLine($"You pressed {c}"))
                .Where(char.IsLetter)
                .SubscribeConsole("Display letters");
        }

        private static IObservable<char> KeyPressObservable() =>
            Observable.Create<char>(observer =>
            {
                while (true)
                {
                    var keypress = Console.ReadKey();
                    Console.WriteLine();
                    if (keypress.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    observer.OnNext(keypress.KeyChar);
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}