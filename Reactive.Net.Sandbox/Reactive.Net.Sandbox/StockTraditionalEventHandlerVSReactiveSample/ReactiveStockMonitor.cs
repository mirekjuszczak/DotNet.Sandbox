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
        private static Dictionary<string, StockInfo> _stockInfos;

        public static void RunReactiveStockMonitor()
        {
            PrepareStockInfos();

            StockTickObservable()
                .DistinctUntilChanged()
                .Subscribe(SendUserNotificationIfChangeRatioGreaterThanMaxChangeRatio);
        }

        private static void SendUserNotificationIfChangeRatioGreaterThanMaxChangeRatio(StockTick stockTick)
        {
            StockInfo? stockInfo = null;
            var quoteSymbol = stockTick.QuoteSymbol;
            var stockInfoExist = _stockInfos.TryGetValue(quoteSymbol, out stockInfo);

            if (stockInfoExist)
            {
                var priceDiff = stockTick.Price - stockInfo.PrevPrevPrice;
                var changeRatio = Math.Abs(priceDiff / stockInfo.PrevPrevPrice);

                if (changeRatio > MaxChangeRatio)
                {
                    //Notify user
                    Console.WriteLine(
                        $"Stock, {quoteSymbol} has changed with {changeRatio} ratio -> Old prevPrice: {stockInfo.PrevPrevPrice}, New prevPrice: {stockTick.Price}");
                }
            }
        }

        private static void PrepareStockInfos()
        {
            _stockInfos = new Dictionary<string, StockInfo>();

            _stockInfos.Add("a", new StockInfo("product_a", 99.99));
            _stockInfos.Add("b", new StockInfo("product_b", 199.99));
            _stockInfos.Add("c", new StockInfo("product_c", 299.99));
            _stockInfos.Add("d", new StockInfo("product_d", 399.99));
            _stockInfos.Add("e", new StockInfo("product_e", 499.99));
            _stockInfos.Add("f", new StockInfo("product_f", 599.99));
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