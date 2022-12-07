using System;
using Reactive.Net.Sandbox.Operators;
using Reactive.Net.Sandbox.Samples;
using Reactive.Net.Sandbox.Samples.StockTraditionalEventHandlerVSReactiveSample;

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
            
            //Convert from event to observable
            FromEventPattern.RunSample();

            //Operators
            //DoOperator.RunSample();
            //SelectOperator.RunSample();
            //BufferOperator.RunSample();

            Console.ReadKey();
        }
    }
}