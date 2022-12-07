using System;

namespace Reactive.Net.Sandbox.Samples.ChatConnectionStructureOnlySample
{
    public static class ChatExtensions
    {
        public static IObservable<string> ToObservable(this IChatConnection connection)
        {
            return new ObservableConnection(connection);
        }
    }
}