var i = 0;

function timedCount() {
    i = i + 1;
    postMessage("WebWorker Message: " + i);
    setTimeout("timedCount()", 500);
}

timedCount();