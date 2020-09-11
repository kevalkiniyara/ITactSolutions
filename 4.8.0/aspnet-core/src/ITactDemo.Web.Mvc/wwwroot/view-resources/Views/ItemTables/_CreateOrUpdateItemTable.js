(function () {
    var imagefile = new Array();
    $("#fileUpload").on("change", function (event) {

        var cred_name = event.target.files[0].name;
        var extension = cred_name.substring(cred_name.lastIndexOf('.') + 1, cred_name.length);

        if (extension !== "jpg" && extension !== "jpeg" && extension != "png") {
            swal("Error", "Please upload .jpg,.jpeg,.png files only.", "error");
            return;
        }
        else {

            imagefile = new Array();
            imagefile.push(event.target.files[0]);
            $('#Image').val(cred_name);
        }

        $("#Image").hide();
        
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#Image").show();
            $("#Image").attr("src", e.target.result);
            $("#Image").Jcrop({
                onChange: SetCoordinates,
                onSelect: SetCoordinates
            });
        }
        $("#fileUpload").hide();
        reader.readAsDataURL($(this)[0].files[0]);
        var type = $(this)[0].files[0].type;

        $("#hdnFileType").val(cred_name);
    });

    $("#btnCrop").on("click", function () {
        
        var x1 = $("#imgX1").val();
        var y1 = $("#imgY1").val();
        var width = $("#imgWidth").val();
        var height = $("#imgHeight").val();
        var canvas = $("#canvas")[0];
        var context = canvas.getContext('2d');
        var img = new Image();
        img.onload = function () {
            canvas.height = height;
            canvas.width = width;
            context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
           $("#imgCropped").val(canvas.toDataURL());
            $("#btnUpload").show();
            $("#btnCrop").hide();
        };
        img.src = $("#Image").attr("src");
        
    });
    function SetCoordinates(c) {
        $("#imgX1").val(c.x);
        $('#imgY1').val(c.y);
        $('#imgWidth').val(c.w);
        $('#imgHeight').val(c.h);
        $('#btnCrop').show();
    }

    $("#btnSave").on("click", function () {

        if (!$('[name="ItemForm"]').valid()) {
            return;
        }
        else {
            debugger
            var _$form = $('[name="ItemForm"]').serializeFormDataToObject();
            var data = new FormData();
            $.each(imagefile, function (key, value) {
                data.append(key, value);
            });
            data.append('Id', _$form.Id);
            data.append("Name",_$form.Name);
            data.append("Price",_$form.Price);
            data.append("Image", _$form.Image);
            data.append("CategoryId", _$form.CategoryId);
            abp.ajax({
                url: '/ItemTables/CreateOrEditItems',
                type: 'post',
                contentType: false,
                processData: false,
                data: data
            }).done(function (response) {
                abp.notify.success("Items saved Successfully");
                alert("Success");
            });
        }
        
    });
    
})();
