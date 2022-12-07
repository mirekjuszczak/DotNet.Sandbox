using System;
using Reactive.Net.Sandbox.Operators;
using Reactive.Net.Sandbox.StockTraditionalEventHandlerVSReactiveSample;

namespace Reactive.Net.Sandbox
{
    //Based on Rx.NET in Action by Tamir Dresher, https://livebook.manning.com/book/rx-dot-net-in-action
    class Program
    {
        static void Main(string[] args)
        {
            //Traditional Event Handler vs Reactive
            //TraditionalEventHandlerStockMonitor.RunTraditionalEventHandlerStockMonitor();
            //ReactiveStockMonitor.RunReactiveStockMonitor();
            
            //Operators
            //DoOperator.RunSample();
            //SelectOperator.RunSample();
            BufferOperator.RunSample();

            Console.ReadKey();
        }
    }
}