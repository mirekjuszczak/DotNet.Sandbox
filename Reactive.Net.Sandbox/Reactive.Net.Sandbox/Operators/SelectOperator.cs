using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Operators
{
    public class SelectOperator
    {
        public static void RunSample()
        {
            var onlySubscriber = wordsObservable();
            onlySubscriber.SubscribeConsole("onlySubscriber");
            
            var subscriberWithSelect = wordsObservable()
                .Select(x => x.ToUpper())
                .Do(Print)
                .SubscribeConsole("subscribeWithSelectAndPrint");
        }

        private static void Print(string str)
        {
            Console.Write($">>> {str} <<<");
        }

        private static IObservable<string> wordsObservable() =>
            Observable.Create<string>(observer =>
            {
                observer.OnNext("One");
                observer.OnNext("Two");
                observer.OnNext("Three");
                observer.OnNext("Four");
                observer.OnNext("Five");
                observer.OnNext("Six");

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}