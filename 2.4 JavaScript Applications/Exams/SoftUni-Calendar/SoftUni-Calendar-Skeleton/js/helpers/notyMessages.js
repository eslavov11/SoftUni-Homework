var app = app || {};

app.notySuccessMessage = function (msg) {
    noty({
        theme: 'relax',
        text: msg,
        type: 'success',
        timeout: 2000,
        closeWith: ['click']
    });
};

app.notyInfoMessage = function (msg) {
    noty({
        theme: 'relax',
        text: msg,
        type: 'info',
        timeout: 2000,
        closeWith: ['click']
    });
};

app.notyErrorMessage = function (msg) {
    noty({
        theme: 'relax',
        text: msg,
        type: 'error',
        timeout: 2000,
        closeWith: ['click']
    });
};
