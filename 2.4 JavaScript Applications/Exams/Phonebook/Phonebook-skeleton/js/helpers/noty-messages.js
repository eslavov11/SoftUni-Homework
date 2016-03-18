var app = app || {};

app.notyMessages = (function() {
    function success(msg) {
        noty({
            text: msg,
            type: 'success',
            layout: 'topCenter',
            timeout: 1000}
        );
    }

    function info(msg) {
        noty({
            text: msg,
            type: 'info',
            layout: 'topCenter',
            timeout: 1000}
        );
    }

    function error(msg) {
        noty({
            text: msg,
            type: 'error',
            layout: 'topCenter',
            timeout: 5000}
        );
    }

    return {
        load: function() {
            return {
                success: success,
                error: error
            }
        }
    }
})();
