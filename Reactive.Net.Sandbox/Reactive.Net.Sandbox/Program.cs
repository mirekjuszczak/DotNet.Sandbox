using System;
using Reactive.Net.Sandbox.Operators;
using Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample;

namespace Reactive.Net.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //Traditional Event Handler vs Reactive
            //TraditionalEventHandlerStockMonitor.RunTraditionalEventHandlerStockMonitor();
            //ReactiveStockMonitor.RunReactiveStockMonitor();
            
            //Operators
            //DoOperator.RunSample();
            BufferOperator.RunSample();
            
            Console.ReadKey();
        }
    }
}