function printArgsInfo(){
    if (arguments.length === 0) {
        console.log('No arguments.');
        return;
    }

    console.log(typeof arguments[0]);
}

printArgsInfo.call(function anotherOne(){});
printArgsInfo.call();
printArgsInfo.apply(function anotherOne(){});
printArgsInfo.apply();