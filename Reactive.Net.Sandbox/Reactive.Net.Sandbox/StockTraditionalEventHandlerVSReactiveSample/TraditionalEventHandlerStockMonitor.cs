using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample
{
    // Example from https://livebook.manning.com/book/rx-dot-net-in-action/chapter-2/9
    // Scenario
    // - Stock update receive
    // - Calculate prevPrice change between current and previous prevPrice
    //   - if (price_change > 10%)  -> Notify user
    //     else -> Wait for next update

    public class TraditionalEventHandlerStockMonitor : IDisposable
    {
        private const double MaxChangeRatio = 0.1;
        private static StockTickerEventHandler _ticker;
        private static Dictionary<string, StockTick> _stockInfos;
        private static object _stockTickerLocker = new();

        public static void RunTraditionalEventHandlerStockMonitor()
        {
            _stockInfos = CommonStockDataGenerator.PrepareStockInfos();

            _ticker = new StockTickerEventHandler();
            _ticker.StockTick += OnStockTick;
        }

        private static void OnStockTick(object sender, StockTick stockTick)
        {
            StockTick? stockInfo = null;
            var quoteSymbol = stockTick.QuoteSymbol;

            lock (_stockTickerLocker)
            {
                var stockInfoExist = _stockInfos.TryGetValue(quoteSymbol, out stockInfo);

                if (stockInfoExist)
                {
                    var priceDiff = stockTick.Price - stockInfo.Price;
                    var changeRatio = Math.Abs(priceDiff / stockInfo.Price);

                    if (changeRatio > MaxChangeRatio)
                    {
                        //Notify user
                        Console.WriteLine(
                            $"Stock, {quoteSymbol} has changed with {changeRatio} ratio -> Old prevPrice: {stockInfo.Price}, New Price: {stockTick.Price}");
                    }
                }
            }
        }

        public void Dispose()
        {
            _ticker.StockTick -= OnStockTick;
            _stockInfos.Clear();
        }
    }

    public class StockTickerEventHandler
    {
        private readonly Dictionary<string, StockTick> _stockInfos = CommonStockDataGenerator.PrepareStockInfos();

        public StockTickerEventHandler()
        {
            Task.Run(ReadNewPrice);
        }

        public event EventHandler<StockTick> StockTick = delegate(object sender, StockTick tick) { };

        private void ReadNewPrice()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                // var keypress = Console.ReadKey();
                // Console.WriteLine();
                // if (keypress.Key == ConsoleKey.Enter)
                //     break;

                var symbol = CommonStockDataGenerator.GetRandomQuoteSymbol();
                var newRandomPriceForSymbol = CommonStockDataGenerator.GetNewRandomPrice(symbol, _stockInfos);

                StockTick(this, new StockTick(symbol, newRandomPriceForSymbol));
            }
        }
    }
}