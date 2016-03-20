var app = app || {};

if (!String.prototype.format) {
    String.prototype.format = function() {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function(match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
}

app.constants = {};
app.constants.APPLICATION_ID = 'kid_WJE8YqETJb';
app.constants.APPLICATION_SECRET = '0352f1dcae404b2ca8fb16148d349cee';
app.constants.BASE_URL = 'https://baas.kinvey.com/';
app.constants.NO_INTERNET_CONNECTION_MSG = 'It appears that your internet connection was lost. Please connect your internet provider.';
app.constants.REGISTER_SUCCESS_MSG = 'Registration was successful.';
app.constants.REGISTER_MISMATCH_PASSWORDS_MSG = 'The provided passwords do not match. Try again.';
app.constants.REGISTER_EXISTING_USER_MSG = 'This username is already taken. Please retry your request with a different username.';
app.constants.LOGIN_SUCCESS_MSG = 'You have successfully logged in.';
app.constants.LOGIN_INVALID_DATA_MSG = 'Your username or password is incorrect.';
app.constants.NOT_LOGGED_IN_MSG = 'You have to be logged in to access this content.';
app.constants.LOGOUT_MSG = 'You have successfully logged out.';
app.constants.ADD_LECTURE_SUCCESS_MSG = 'Lecture "{0}" added successfully.';
app.constants.ADD_LECTURE_ERROR_MSG = 'Something went wrong with adding the lecture. Try again.';
app.constants.EDIT_LECTURE_SUCCESS_MSG = 'Lecture "{0}" edited successfully.';
app.constants.EDIT_LECTURE_ERROR_MSG = 'You don\'t have the privileges to edit this lecture.';
app.constants.DELETE_LECTURE_SUCCESS_MSG = 'Lecture deleted successfully.';
app.constants.DELETE_LECTURE_ERROR_MSG = 'You don\'t have the privileges to delete this lecture.';