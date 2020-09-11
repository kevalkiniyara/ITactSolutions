(function () {
    
    var stateId = $("#State");
    var cityId = $("#City");
    var _customerService = abp.services.app.customer;
    var imagefile = new Array();

    $("#customerimage").on("change", function (event) {

        var imageValue = event.target.files[0].name;
        var extension = imageValue.substring(imageValue.lastIndexof(.) + 1, imageValue.length);
        if (extension !== ".jpg" && extension !== ".jpeg" && extension !== png) {
            swal("error");
            return;
        }
        else {

            imagefile.push(event.target.files[0]);
            $("#customerimage").val(imageValue);
        }
    });

    $("#Country").on("change", function () {
        
        var country = $(this).val();
        _customerService.stateComboBoxDto(country).done(function (responses) {
            if (responses != null) {
                stateId.find('option').remove();
                stateId.append("<option value=''>Select</option>");
                $.each(responses, function (index, item) {
                    stateId.append($('<option/>', {
                        value: item.value,
                        text: item.displayText,
                        selected: item.isSelected ? true : false
                    }));
                });
            }
        });

        $("#State").on("change", function () {
            
            var state = $(this).val();
            _customerService.cityComboBoxDto(state).done(function (responses) {
                if (responses != null) {
                    cityId.find('option').remove();
                    cityId.append("<option value=''>Select</option>");
                    $.each(responses, function (index, item) {
                        cityId.append($('<option/>', {
                            value: item.value,
                            text: item.displayText,
                            selected: item.isSelected ? true : false
                        }));
                    });
                }
            });
        });
    });

    $("#btnSave").on("click", function () {

        if (!$('[name="CustomerForm"]').valid()) {
            return;
        }
        else {

            var _$form = $('[name=CustomerForm]').serializeFormToObject();
            var form = new FormData();
            $.each(imagefile, function (key, value) {
                form.append(key, value);
            });
        }

    });
    
})();