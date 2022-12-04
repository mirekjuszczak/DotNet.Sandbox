using System.Collections.Generic;

namespace Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample
{
    public class CommonStockDataGenerator
    {
        public static Dictionary<string, StockInfo> PrepareStockInfos()
        {
            var stockInfos = new Dictionary<string, StockInfo>();

            stockInfos.Add("a", new StockInfo("product_a", 99.99));
            stockInfos.Add("b", new StockInfo("product_b", 199.99));
            stockInfos.Add("c", new StockInfo("product_c", 299.99));
            stockInfos.Add("d", new StockInfo("product_d", 399.99));
            stockInfos.Add("e", new StockInfo("product_e", 499.99));
            stockInfos.Add("f", new StockInfo("product_f", 599.99));

            return stockInfos;
        }
    }
}