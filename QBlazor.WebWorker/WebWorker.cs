using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace QBlazor.WebWorker
{
    public interface IWorker
    {
        Task Start(string url);

        Task Stop();

        Action<object> Message { get; set; }

        Action<object> Error { get; set; }

        Action Terminate { get; set; }
    }

    public class Worker : IWorker
    {
        Interop interop;

        public Worker(IJSRuntime jsRuntime)
        {
            var helper = new Helper();
            interop = new Interop(jsRuntime, helper);

            helper.Message += (o) => this.Message(o);
            helper.Error += (o) => this.Error(o);
            helper.Terminate += () => this.Terminate();
        }

        public Action<object> Message { get; set; }

        public Action<object> Error { get; set; }

        public Action Terminate { get; set; }

        public async Task Start(string url) => await this.interop.Start(url);

        public async Task Stop() => await this.interop.Stop();
    }
}