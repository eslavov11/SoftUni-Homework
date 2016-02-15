function pop(type, title, message) {
    var popup;
    switch (type) {
        case 'success':
            popup = new Success(type, title, message);
            break;
        case 'info':
            popup = new Info(type, title, message);
            break;
        case 'error':
            popup = new Error(type, title, message);
            break;
        case 'warning':
            popup = new Warning(type, title, message);
            break;
        default:
            throw new Error('No such popup exists.');
            break;
    }
	// generate view from view factory
    var view = createPopupView(popup);

    processPopup(view, popup);

    var popupElement = document.getElementsByClassName(view.className)[0];
    if (popup.closeButton) {
        var closeButton = document.getElementsByClassName("poppy-close-button")[0];

        closeButton.addEventListener("click", function(){
            var button = document.getElementsByClassName("poppy-close-button")[0];
            fadeOut(popupElement, popup.timeout);
        });
    }

    if (popup.autoHide) {
        fadeOut(popupElement, popup.timeout);
    }
}

function processPopup(domView, popup) {
    document.body.appendChild(domView);

    var popupElement = document.getElementsByClassName(domView.className)[0];
    fadeIn(popupElement);
}

function fadeOut(element, interval) {
    var op = 1;  // initial opacity
    var timer = setInterval(function () {
        if (op <= 0.1){
            clearInterval(timer);
            element.style.display = 'none';
        }
        element.style.opacity = op;
        element.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op -= op * 0.1;
    }, interval);
}

function fadeIn(element) {
    var op = 0.1;  // initial opacity
    var timer = setInterval(function () {
        if (op >= 1){
            clearInterval(timer);
            //element.style.display = 'none';
        }
        element.style.opacity = op;
        element.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op += op * 0.1;
    }, 50);
}


pop('success', 'Bravo', 'you won');
//pop('info', 'Bravo', 'you won');
pop('info', '222', 'you won');
pop('error', 'Bravo', 'you won');
pop('warning', 'Bravo', 'you won');




