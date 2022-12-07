using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Samples.ChatConnectionStructureOnlySample
{
    public class ChatTrackerWholeService
    {
        public ChatTrackerWholeService()
        {
            var chatClient = new ChatClient();
            
            //not needed if ToObservable in ChatExtentions added
            //var connection = chatClient.Connect("quest", "password");
            //IObservable<string> observableConnection = new ObservableConnection(connection);

            var subscription = chatClient.Connect("quest", "password")
                .ToObservable()
                .SubscribeConsole("receiver");
        }
    }
}