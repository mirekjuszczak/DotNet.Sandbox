using System;
using Reactive.Net.Sandbox.Operators;
using Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample;

namespace Reactive.Net.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            TraditionalStockMonitor.RunTraditionalStockMonitor();
            
            //DoOperator.RunSample();
            
            Console.ReadKey();
        }
    }
}