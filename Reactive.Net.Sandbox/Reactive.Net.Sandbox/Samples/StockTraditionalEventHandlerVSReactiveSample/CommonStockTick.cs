namespace Reactive.Net.Sandbox.Samples.StockTraditionalEventHandlerVSReactiveSample
{
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
}