using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Operators
{
    public class BufferOperator
    {
        public static void RunSample()
        {
            Console.WriteLine("Groups of numbers: ");
            Console.WriteLine();

            NumbersObservable()
                .Buffer(5)
                .Do(PrintAllNumbersFromBuffer)
                .SubscribeConsole("Number groups");
        }

        private static void PrintAllNumbersFromBuffer(IList<int> listNumbers)
        {
            foreach (var number in listNumbers)
            {
                Console.Write($"{number:00}  ");
            }
        }

        private static IObservable<int> NumbersObservable() =>
            Observable.Create<int>(observer =>
            {
                for (int i = 1; i <= 25; i++)
                {
                    observer.OnNext(i);
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}