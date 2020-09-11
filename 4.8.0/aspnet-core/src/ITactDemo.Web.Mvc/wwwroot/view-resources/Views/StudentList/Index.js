(function () {
    
    $("#btnUpload").on("click", function (event) {
        var filename = $("#fileupload").val();
        
        var extension = filename.substring(filename.lastIndexOf('.') + 1, filename.length);
        if (extension !== "xls" && extension !== "xlsx") {
            swal("Error", "Please upload .xsl files only.", "error");
            return;
        }
        var data = new FormData();
        var fileUpload = $("#fileupload").get(0);
        var files = fileUpload.files;
        data.append(files[0].name, files[0]);

        $.ajax({
            url: "/StudentLists/Import",
            type: 'post',
            contentType: false,
            processData: false,
            data: data,
            success: function (response) {
                $('#PrintExcel').html(response);
            }
        });
    });
})();