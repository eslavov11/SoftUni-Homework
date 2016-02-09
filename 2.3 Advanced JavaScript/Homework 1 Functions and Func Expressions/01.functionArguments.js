function printArgsInfo(){
    console.log(typeof arguments[0]);
}

printArgsInfo('String');
printArgsInfo(true);
printArgsInfo(undefined);
printArgsInfo(5);
printArgsInfo([1, "2", function wut(){}, {name: "Name"}]);
printArgsInfo(function anotherOne(){});