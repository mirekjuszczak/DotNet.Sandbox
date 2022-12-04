using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample
{
    // Example from https://livebook.manning.com/book/rx-dot-net-in-action/chapter-2/9
    // Scenario
    // - Stock update receive
    // - Calculate prevPrice change between current and previous prevPrice
    //   - if (price_change > 10%)  -> Notify user
    //     else -> Wait for next update

    public class ReactiveStockMonitor
    {
        private const double MaxChangeRatio = 0.1;
        private static Dictionary<string, StockTick> _stockInfos;

        public static void RunReactiveStockMonitor()
        {
            _stockInfos = CommonStockDataGenerator.PrepareStockInfos();

            StockTickObservable()
                .DistinctUntilChanged()
                .Subscribe(SendUserNotificationIfChangeRatioGreaterThanMaxChangeRatio);
        }

        private static void SendUserNotificationIfChangeRatioGreaterThanMaxChangeRatio(StockTick stockTick)
        {
            StockTick? stockInfo = null;
            var quoteSymbol = stockTick.QuoteSymbol;
            var stockInfoExist = _stockInfos.TryGetValue(quoteSymbol, out stockInfo);

            if (stockInfoExist)
            {
                var priceDiff = stockTick.Price - stockInfo.Price;
                var changeRatio = Math.Abs(priceDiff / stockInfo.Price);

                if (changeRatio > MaxChangeRatio)
                {
                    //Notify user
                    Console.WriteLine(
                        $"Stock, {quoteSymbol} has changed with {changeRatio} ratio -> Old prevPrice: {stockInfo.Price}, New prevPrice: {stockTick.Price}");
                }
            }
        }

        private static IObservable<StockTick> StockTickObservable() =>
            Observable.Create<StockTick>(observer =>
            {
                string? key;
                double value = 0;
            
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.White;

                while (true)
                {
                    Console.Write("Pass Key of product (a, b, c, d, e, other): ");
                    // var consoleKey = Console.ReadLine();
                    // key = consoleKey;
                    key = "c";

                    Console.WriteLine($"Pass new price for product {key}: ");
                    // var consoleValue = Console.ReadLine();
                    var consoleValue = "700.45";

                    if (key != null && Double.TryParse(consoleValue, out value))
                    {
                        observer.OnNext(new StockTick(key, value));
                    }
                }
                
                observer.OnCompleted();
                return Disposable.Empty;
            });
    }
}