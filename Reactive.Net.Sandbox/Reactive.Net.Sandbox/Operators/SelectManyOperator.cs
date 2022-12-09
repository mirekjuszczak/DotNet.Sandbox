using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Operators
{
    //SelectMany projects each element of an observable sequence to an enumerable sequence and concatenates the enumerables into one observable sequence
    //ex. nested observable sequence { {1,2}, {3,4,5}, {6,7}} -> { 1,2,3,4,5,6,7 }
    
    public class SelectManyOperator
    {
        public class ObservableItem
        {
            public string ParentObservableName { get; set; }
            public string ItemOfParentValue { get; set; }

            public override string ToString() => $" -> {ParentObservableName}-{ItemOfParentValue}";
        }

        public static void RunEnumerableSample()
        {
            NestedEnumerable
                .SelectMany(x => x)
                .Subscribe(x=> Console.WriteLine($"{x}"));
        }
        
        public static void RunObservableSample()
        {
            NestedObservable
                .SelectMany(x => x)
                .Subscribe(x=> Console.WriteLine($"{x}"));
        }

        private static IObservable<IEnumerable<ObservableItem>> NestedEnumerable =>
            Observable.Create<IEnumerable<ObservableItem>>(observer =>
            {
                observer.OnNext(PeriodicallyItemsObservable("FirstParentEnumerable").ToEnumerable());
                observer.OnNext(PeriodicallyItemsObservable("SecondParentEnumerable").ToEnumerable());
                observer.OnNext(PeriodicallyItemsObservable("ThirdParentEnumerable").ToEnumerable());
                observer.OnNext(PeriodicallyItemsObservable("FourthParentEnumerable").ToEnumerable());
                observer.OnNext(PeriodicallyItemsObservable("FifthParentEnumerable").ToEnumerable());

                observer.OnCompleted();
                return Disposable.Empty;
            });
        
        private static IObservable<IObservable<ObservableItem>> NestedObservable =>
            Observable.Create<IObservable<ObservableItem>>(observer =>
            {
                observer.OnNext(PeriodicallyItemsObservable("FirstParentObservable"));
                observer.OnNext(PeriodicallyItemsObservable("SecondParentObservable"));
                observer.OnNext(PeriodicallyItemsObservable("ThirdParentObservable"));
                observer.OnNext(PeriodicallyItemsObservable("FourthParentObservable"));
                observer.OnNext(PeriodicallyItemsObservable("FifthParentObservable"));

                observer.OnCompleted();
                return Disposable.Empty;
            });

        private static IObservable<ObservableItem> PeriodicallyItemsObservable(string nameOfParent) =>
            Observable.Create<ObservableItem>(async observer =>
            {
                var rnd = new Random();

                for (int i = 1; i < 6; i++)
                {
                    await Task.Delay(rnd.Next(100, 500));
                    observer.OnNext(new ObservableItem
                        { ParentObservableName = nameOfParent, ItemOfParentValue = i.ToString() });
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}