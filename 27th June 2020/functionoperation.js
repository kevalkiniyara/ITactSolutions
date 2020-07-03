function Addition(a,b)
{
    return a*b;
}
document.getElementById("demo").innerHTML=Addition(5,10);
var x=Addition(10,20);
document.writeln(x);

var anon= function (a,b)
{
console.log("Anonymous Method");
return a+b;
}
document.writeln(anon(10,20));

function (a,b)
{
    console.log("Invoking");
    return a+b;
}(2,6);
