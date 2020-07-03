function loadFunction()
{
    var http=new XMLHttpRequest();
    http.onreadystatechange=function()
    {
        if(this.readyState==4 && this.status==200)
        {
            document.getElementById("demo").innerHTML=this.responseText;
        }
    };
    http.open("GET","D:\Javascript\ITactSolutions\28th June 2020\ajax_info.txt",true);
    http.send();
}