function pop(type, title, message) {
    var popup;
    switch (type) {
        case 'success':
            popup = new Success(title, message);
            break;
        case 'info':
            popup = new Info(title, message);
            break;
        case 'error':
            popup = new Error(title, message);
            break;
        case 'warning':
            popup = new Warning(title, message);
            break;
        default:
            throw new Error('No such popup exists.');
            break;
    }
	// generate view from view factory
    var view = createPopupView(popup);

    processPopup(view, popup);
}

function processPopup(domView, popup) {
	// TODO: Implement popup logic
}
