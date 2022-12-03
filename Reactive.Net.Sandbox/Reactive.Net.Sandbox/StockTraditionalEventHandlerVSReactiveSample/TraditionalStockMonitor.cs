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

    public class TraditionalStockMonitor : IDisposable
    {
        private const double MaxChangeRatio = 0.1;
        private static StockTickerEventHandler _ticker;
        private static Dictionary<string, StockInfo> _stockInfos;

        public static void RunTraditionalStockMonitor()
        {
            PrepareStockInfos();
            
            _ticker = new StockTickerEventHandler();
            _ticker.StockTick += OnStockTick;
        }

        private static void OnStockTick(object sender, StockTick stockTick)
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
                    Console.WriteLine($"Stock, {quoteSymbol} has changed with {changeRatio} ratio -> Old prevPrice: {stockInfo.PrevPrevPrice}, New prevPrice: {stockTick.Price}");
                }
            }
        }

        private static void PrepareStockInfos()
        {
            _stockInfos = new Dictionary<string, StockInfo>();
            
            _stockInfos.Add("a", new StockInfo("product_1", 99.99));
            _stockInfos.Add("b", new StockInfo("product_2", 199.99));
            _stockInfos.Add("c", new StockInfo("product_3", 299.99));
            _stockInfos.Add("d", new StockInfo("product_4", 399.99));
            _stockInfos.Add("e", new StockInfo("product_5", 499.99));
            _stockInfos.Add("f", new StockInfo("product_6", 599.99));
        }

        public void Dispose()
        {
            _ticker.StockTick -= OnStockTick;
            _stockInfos.Clear();
        }
    }

    public class StockTick
    {
        public StockTick(string quoteSymbol, double price)
        {
            QuoteSymbol = quoteSymbol;
            Price = price;
        }
        
        public string QuoteSymbol { get; set; }
        public double Price { get; set; }
    }

    public class StockInfo
    {
        public StockInfo(string quoteSymbol, double prevPrice)
        {
            QuoteSymbol = quoteSymbol;
            PrevPrevPrice = prevPrice;
        }

        public string QuoteSymbol { get; }
        public double PrevPrevPrice { get; }
    }
    
    public class StockTickerEventHandler
    {
        public StockTickerEventHandler()
        {
            Task.Run(ReadNextPrice);
        }
        
        public event EventHandler<StockTick> StockTick = delegate(object sender, StockTick tick) {  };

        private void ReadNextPrice()
        {
            string? key;
            double value;
            
            Console.WriteLine();
            
            while (true)
            {
                Console.Write("Pass Key of product (a, b, c, d, e, other): ");
                // var consoleKey = Console.ReadLine();
                // key = consoleKey;
                key = "c";
                
                Console.WriteLine($"Pass new price for product {key}: ");
                //var consoleValue = Console.ReadLine();
                var consoleValue = "302.45";

                if (key != null  && Double.TryParse(consoleValue, out value))
                {
                    StockTick(this, new StockTick(key, value));    
                }
            }
        }
    }
}