using System;
using System.Collections.Concurrent;

namespace Reactive.Net.Sandbox.Samples.StockTraditionalEventHandlerVSReactiveSample
{
    public class CommonStockDataGenerator
    {
        public static ConcurrentDictionary<string, StockTick> PrepareStockInfos()
        {
            var stockInfos = new ConcurrentDictionary<string, StockTick>();

            _ = stockInfos.TryAdd("a", new StockTick("product_a", 99.99));
            _ = stockInfos.TryAdd("b", new StockTick("product_b", 199.99));
            _ = stockInfos.TryAdd("c", new StockTick("product_c", 299.99));
            _ = stockInfos.TryAdd("d", new StockTick("product_d", 399.99));
            _ = stockInfos.TryAdd("e", new StockTick("product_e", 499.99));
            _ = stockInfos.TryAdd("f", new StockTick("product_f", 599.99));

            return stockInfos;
        }

        public static string GetRandomQuoteSymbol()
        {
            var rnd = new Random();
            var index = rnd.Next(1, 10);

            return index switch
            {
                1 => "a",
                2 => "b",
                3 => "c",
                4 => "d",
                5 => "e",
                6 => "f",
                _ => "other"
            };
        }

        public static double GetNewRandomPrice(string quoteSymbol, ConcurrentDictionary<string, StockTick> stockInfos)
        {
            var rnd = new Random();
            StockTick? stockInfo = null;
            var stockInfoExist = stockInfos.TryGetValue(quoteSymbol, out stockInfo);
            var previousPrice = (double)300;

            if (stockInfoExist)
            {
                previousPrice = stockInfo!.Price;
            }

            var changeRatio = (double)rnd.Next(0, 20) / 100;
            var newPrice = previousPrice + previousPrice * changeRatio;

            return newPrice;
        }
    }
}