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
    }
}