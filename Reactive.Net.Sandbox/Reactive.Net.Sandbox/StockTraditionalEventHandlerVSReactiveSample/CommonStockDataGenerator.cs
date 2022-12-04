using System;
using System.Collections.Generic;

namespace Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample
{
    public class CommonStockDataGenerator
    {
        public static Dictionary<string, StockTick> PrepareStockInfos()
        {
            var stockInfos = new Dictionary<string, StockTick>();

            stockInfos.Add("a", new StockTick("product_a", 99.99));
            stockInfos.Add("b", new StockTick("product_b", 199.99));
            stockInfos.Add("c", new StockTick("product_c", 299.99));
            stockInfos.Add("d", new StockTick("product_d", 399.99));
            stockInfos.Add("e", new StockTick("product_e", 499.99));
            stockInfos.Add("f", new StockTick("product_f", 599.99));

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

        public static double GetNewRandomPrice(string quoteSymbol, Dictionary<string, StockTick> stockInfos)
        {
            var rnd = new Random();
            StockTick? stockInfo = null;
            var stockInfoExist = stockInfos.TryGetValue(quoteSymbol, out stockInfo);
            var previousPrice = (double)300;

            if (stockInfoExist)
            {
                previousPrice = stockInfo!.Price;
            }

            var changeRatio = (double)rnd.Next(0, 20) / 10;
            var newPrice = previousPrice + previousPrice * changeRatio;

            return newPrice;
        }
    }
}