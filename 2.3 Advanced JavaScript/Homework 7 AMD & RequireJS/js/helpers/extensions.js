Array.prototype.clone = function() {
    var result = new Array(this.length);
    var i = result.length;
    while(i--) { result[i] = this[i]; }

    return result;
};

function appendElementsToParentSelector() {
    var i, parent;
    if(arguments[0]) {
        parent = document.getElementById(arguments[0]);
        for (i = 1; i < arguments.length; i++) {
            parent.appendChild(arguments[i]);
        }
    }
}
function appendElementsToParent() {
    var i, parent;
    if(arguments[0]) {
        parent = arguments[0];
        for (i = 1; i < arguments.length; i++) {
            parent.appendChild(arguments[i]);
        }
    }
}