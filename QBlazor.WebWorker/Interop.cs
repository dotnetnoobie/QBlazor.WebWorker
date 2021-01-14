using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace QBlazor.WebWorker
{
    public class Interop
    {
        private IJSObjectReference module;
        private readonly IJSRuntime jsRuntime;
        private DotNetObjectReference<Helper> objRef;

        public Interop(IJSRuntime jsRuntime, Helper helper)
        {
            this.jsRuntime = jsRuntime;
            this.objRef = DotNetObjectReference.Create(helper);
        }

        public async Task Initialize(string url)
        {
            module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/QBlazor.WebWorker/setup.js");

            await module.InvokeVoidAsync("Initialize", objRef, url);
        }

        public async Task Start(string url) => await this.Initialize(url);

        public async Task Stop() => await module.InvokeVoidAsync("Terminate");

        public void Dispose() => this.objRef?.Dispose();
    }
}