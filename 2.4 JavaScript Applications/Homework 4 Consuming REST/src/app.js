var app = app || {};

app.requester.config('kid_bkeREc9VJZ', 'e0a07a1765cb4b4cbfaf3dac70156325');
var userRequester = new app.UserRequester();
//userRequester.signUp('peter', 'pass123');
userRequester.login('peter', 'pass123');

app.getBooks();