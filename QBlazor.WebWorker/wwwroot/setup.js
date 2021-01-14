let worker = undefined;
let dotnet = undefined;

export function Initialize(objRef, url) {
    if (typeof (worker) == "undefined") {
        worker = new Worker(url);
        dotnet = objRef;
    }
    worker.onmessage = (event) => dotnet.invokeMethodAsync('OnMessage', event.data);
    worker.onerror = (error) => dotnet.invokeMethodAsync('OnError', error.message);
};

export function Terminate() {
    worker?.terminate();
    worker = undefined;
    dotnet.invokeMethodAsync('OnTerminate');
};