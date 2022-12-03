using System;

namespace Reactive.Net.Sandbox.ConsoleObserver
{
    public static class Extentions
    {
        public static IDisposable SubscribeConsole<T>(this IObservable<T> observable, string observerName) =>
            observable.Subscribe(new ConsoleObserver<T>(observerName));
    }
}