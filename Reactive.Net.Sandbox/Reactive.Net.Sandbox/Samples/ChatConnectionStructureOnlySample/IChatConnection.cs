using System;

namespace Reactive.Net.Sandbox.Samples.ChatConnectionStructureOnlySample
{
    public interface IChatConnection
    {
        //Raised when chat message received --> OnNext
        event Action<string> Received;
        //Raised when the connection closed --> OnCompleted
        event Action Closed;
        //Raised when unexpected error occured --> OnError
        event Action<Exception> Error;

        void Disconnected();
    }

    public class ChatConnection : IChatConnection
    {
        public event Action<string>? Received;
        public event Action? Closed;
        public event Action<Exception>? Error;
        public void Disconnected()
        {
            //Disconnect from chat service
        }
    }
}