(function(){
    $(function () {
        var profession = $("#profession").val();
       
        $("#AddClass").on("click", function () {
            $(".names").addClass("addColor");
            
        });

        $("#AddAttr").on("click", function () {
            debugger
            $("img").attr("width", "500");
        });

        $("#HasClass").on("click", function () {
            alert($(".names").hasClass("addColor"));
        });

        $("#HtmlValue").on("click", function () {
            $(".htmlval").html("Valsad");
        });

        $("#PropValue").on("click", function () {

            var hobby = [];
            $(".hobby").each(function () {

                var $this = $(this).val();
                if ($this.prop("checked")) {
                    hobby.push($this);
                }
                console.log(hobby);
            });
        });
        $("#RemoveAttr").on("click", function () {
            $(".names").removeAttr("addColor");
        });

        $("#CallBackfun").on("click", function () {
            $("#callval").hide("slow", function () {
                alert("Paragraph is hide");
            });
        })

        $("blurFocus").blur(function () {
            alert("lost the focus");
        });

        $("#ChangeFunction").on("change", function () {

            var $this = $(this).val();
            alert($this); 
        });

        $("#doubleclick").dblclick(function () {
            alert("Double Click is fired");
        });

        $("#delegate").delegate("p", "click", function () {
            $("p").css("background-color", "pink");
        });
        $("#DefaultPrevent").on("click", function (e) {
            e.preventDefault();
            alert("Method called" + e.isDefaultPrevented());
        });
        function getRelatedElement(event) {
            alert(event.relatedTarget.tagName);
        }

        $("#Result").on("click", function () {
            return "Hello Keval";

        });
        $("#Result").on("click", function (e) {

            alert(e.result);
            alert(e.type);
        });
        $("#target").on("click", function (e) {
            alert(e.target.nodeName);
            alert(e.timeStamp);
        });

        $("#whichval").on("keydown", function (e) {
            alert(e.which);
        });

        $("#keydown").on("keydown", function () {
            alert("keyDown")
        });

        $("#mouse").on("mousedown", function () {
            alert("mouse down");
        })
        $("#mouseUp").on("mouseup", function () {
            alert("mouse up");
        });
        $("#mouseenter").on("mouseenter", function () {
            alert("mouse up");
        });
        $("#select").select(function () {
            alert("marked");
        })
        $("form").submit(function () {
            alert("Submitted");
        });

        $("#btntoggle").on("toggle",function () {

            alert("toggle");
        });

        $("#copyval").on("oncopy", function () {
            alert("you copied");
        });

        /////////////////////////////////////////////////////////////////////////////////


        $("#clonefun").on("click", function () {
            $("#clonevalue").clone().appendTo("#clonevalue");
        });
        $("#wrapfun1").on("click", function () {

            $("p").wrap("<div></div>");
        })

        $("#wrapfun2").on("click", function () {

            $("p").wrapAll("<div></div>");
        })

        $("#wrapfun3").on("click", function () {

            $("p").unwrap("<div></div>");
        })


        $("#wrapfun4").on("click", function () {

            $("p").wrapInner("<b></b>");
        });

        $("#appendfun").on("click", function () {
            $("#clonevalue").append("<b>keval</b>");
        });

        $("#appendTofun").on("click", function () {
            $("<span>keval123</span>").appendTo("#clonevalue");
        });

        $("#prependfun").on("click", function () {
            $("#clonevalue").prepend("<b>keval</b>");
        });

        $("#prependTofun").on("click", function () {
            $("<span>keval123</span>").prependTo("#clonevalue");
        });

        $("#textfun").on("click", function () {
            $("#clonevalue").text("Valsad");
        });

        $("#afterfun").on("click", function () {
            $("#clonevalue").after("<p>Valsad</p>");
        });
        $("#beforefun").on("click", function () {
            $("#clonevalue").before("<p>Valsad</p>");
        });

        $("#insertafterfun").on("click", function () {
            $("<span>keval123</span>").insertAfter("#clonevalue");
        });

        $("#inserbeforefun").on("click", function () {
            $("<span>keval123</span>").insertBefore("#clonevalue");
        });

        $("#detachfun").on("click", function () {
            $("#clonevalue").detach();
        });
        $("#emptyfun").on("click", function () {
            $("#clonevalue").empty();
        });

        $("#removefun").on("click", function () {
            $("#clonevalue").remove();
        });

        $("#replacefun").on("click", function () {
            $("<p>hello Itact</p>").replaceAll("#clonevalue")
        });

        $("#cssfun").on("click", function () {
            alert($("#cloneval").innerHeight());
        });

        var person = new Object();
        person.name = "keval";
        person.age = 20
        $("#paramfun").on("click", function () {
            alert($.param(person));
        });

        var obj1 = ["Keval","123"];
        var obj2 = ["Kiniyara"];
        
        
        obj1.push("Manojbhai")
        
        obj1[0] = "Kmk";
        var name = obj1.concat(obj2);
        console.log(name);
        console.log(name.reverse());
        

        var val1 = [4, 16, 25, 16];
        function check(val) {
            return val >= 18;
        }
        
        console.log(val1.every(check));
        console.log(val1.filter(check));
        console.log(val1.find(check));
        console.log(val1.findIndex(check));
        console.log(obj1.indexOf("123"));
        console.log(obj1.join("and"))

        var keyVal = val1.keys();
        for (i of keyVal) {
            console.log(i);
        }
        console.log(val1.length);
        console.log(val1.lastIndexOf(25));
        console.log(val1.map(Math.sqrt));
        console.log(obj1.reverse);

        var d = new Date();
        console.log(d.getDate())
        console.log(d.getDay())
        console.log(d.getFullYear())
        console.log(d.getMinutes())
        console.log(d.getTime())
        console.log(d.getUTCHours())
        console.log(d.toJSON())
        console.log(d.toLocaleTimeString())
        console.log(d.toLocaleString());


        $("#btnOrder").on("click", function () {
            
            var val = document.createElement("LI");
            var text = document.createTextNode("Coffee");
            val.appendChild(text);
            document.getElementById("orderList").appendChild(val);
            
        });

        $("#hasAt").on("click", function () {
            var x = document.getElementById("hasAt").hasAttribute("class");
            console.log(x);
        });

        $("#hasAtChild").on("click", function () {
            var y = document.getElementById("orderList").hasChildNodes();
            console.log(y);
        });

        $("#getId").on("click", function () {

            var a = (".Values")[0].id;
            console.log(a);
        })

        
    });

})();