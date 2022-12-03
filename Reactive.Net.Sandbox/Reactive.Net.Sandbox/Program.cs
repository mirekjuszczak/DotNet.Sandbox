using System;
using Reactive.Net.Sandbox.Operators;
using Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample;

namespace Reactive.Net.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //TraditionalEventHandlerStockMonitor.RunTraditionalEventHandlerStockMonitor();
            ReactiveStockMonitor.RunReactiveStockMonitor();
            
            //DoOperator.RunSample();
            
            Console.ReadKey();
        }
    }
}