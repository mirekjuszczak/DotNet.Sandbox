using System;

namespace Reactive.Net.Sandbox.ConsoleObserver
{
    public class ConsoleObserver<T> : IObserver<T>
    {
        private readonly string _observerName;

        public ConsoleObserver(string observerName)
        {
            _observerName = observerName;
        }
        
        public void OnCompleted()
        {
            Console.WriteLine($"[{_observerName}] OnCompleted...");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"[{_observerName}] OnError...");
        }

        public void OnNext(T value)
        {
            Console.WriteLine($"[{_observerName}] OnNext...");
        }
    }
}