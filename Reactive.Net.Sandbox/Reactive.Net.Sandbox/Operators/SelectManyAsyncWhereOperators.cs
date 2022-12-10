using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Reactive.Net.Sandbox.Operators
{
    //Where operator expects from the given predicate to return a Boolean that will determine whether the item will be allowed to proceed on the observable.
    //But the IsPrimeAsync method returns a Task<bool>
    //So Task<bool> can become an IObservable<bool> on which the Where operator can work without a problem
    
    public class SelectManyAsyncWhereOperators
    {
        public class ObservableItem
        {
            public ObservableItem(int number, bool isEven)
            {
                Number = number;
                IsEven = isEven;
            }
            
            public int Number { get; set; }
            public bool IsEven { get; set; }
        }

        public static void RunSample()
        {
            Observable
                .Range(1, 10)
                .SelectMany(number => IsEvenNumberCheckingWithDelay(number), (number, even) => new ObservableItem(number, even))
                .Where(x=> x.IsEven)
                .Subscribe(x => Console.WriteLine($"{x.Number} is event number? {x.IsEven}"));
        }

        private static async Task<bool> IsEvenNumberCheckingWithDelay(int number)
        {
            var rnd = new Random();
            await Task.Delay(rnd.Next(100, 500));
            return number % 2 == 0;
        }
    }
}