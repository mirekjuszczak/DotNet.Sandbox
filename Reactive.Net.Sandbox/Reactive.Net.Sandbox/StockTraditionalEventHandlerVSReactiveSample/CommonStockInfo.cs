namespace Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample
{
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
}