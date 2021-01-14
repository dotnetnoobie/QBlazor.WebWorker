using System;
using Microsoft.JSInterop;

namespace QBlazor.WebWorker
{
    public class Helper
    {
        public Action<object> Message { get; set; }

        public Action<object> Error { get; set; }

        public Action Terminate { get; set; }

        [JSInvokable]
        public void OnMessage(object data)
        {
            Console.WriteLine("OnMessage: " + data);

            this.Message?.Invoke(data);
        }

        [JSInvokable]
        public void OnError(object error)
        {
            Console.WriteLine("OnError: " + error);

            this.Error?.Invoke(error);
        }

        [JSInvokable]
        public void OnTerminate()
        {
            Console.WriteLine("OnTerminate");

            this.Terminate?.Invoke();
        }
    }
}