(function () {

    var _studentService = abp.services.app.student;
    var imagefile = new Array();

    var stateId = $("#State");
    var cityId = $("#City");


    $("#removeImage").click(function (e) {

        e.preventDefault();
        $(this).remove();
        $("#StudentImage").val("");
        $("#studentImagePic").hide();
    });

    $("#Country").on("change", function () {
        
        var countryValue = $(this).val();
        _studentService.getStateComboboxDto(countryValue).done(function (responses) {
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
            var stateValue = $(this).val();
            _studentService.getCityComboboxDto(stateValue).done(function (responses) {
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
    })
    
    $('#datepicker').datepicker({
        format: 'mm/dd/yyyy',
        autoclose: true,
    });

    $(".studentImage").on("change", function (event) {
        var cred_name = event.target.files[0].name;
        var extension = cred_name.substring(cred_name.lastIndexOf('.') + 1, cred_name.length);

        if (extension !== "jpg" && extension !== "jpeg" && extension != "png") {
            swal("Error", "Please upload .jpg,.jpeg,.png files only.", "error");
            return;
        }
        else {
            
            imagefile = new Array();
            imagefile.push(event.target.files[0]);
            $('#image').val(cred_name);
        }
    });

    
    $("#btnSave").on("click", function () {
        
        if (!$('[name="StudentEditForm"]').valid()) {
            return;
        }
        else {
            var _$Form = $('[name="StudentEditForm"]').serializeFormDataToObject();
            var data = new FormData();
            $.each(imagefile, function (key, value) {
                data.append(key, value);
            });

            data.append('Id', _$Form.Id);
            data.append('FirstName', _$Form.FirstName);
            data.append('LastName', _$Form.LastName);
            data.append('Email', _$Form.Email);
            data.append('PhoneNumber', _$Form.PhoneNumber);
            data.append('Standard', _$Form.Standard);
            data.append('BirthDate', _$Form.BirthDate);
            data.append('StudentImage', _$Form.StudentImage)
            data.append('CountryId', _$Form.CountryId);
            data.append('StateId', _$Form.StateId);
            data.append('CityId', _$Form.CityId);
            data.append('Gender', _$Form.Gender);

            $('.chkHobbies').each(function () {
                var $this = $(this)
                if ($this.prop("checked")) {
                    data.append('HobbiesIds', $this.val());
                }
            });

            abp.ajax({
                url: '/Students/CreateOrEditStudent',
                type: 'post',
                contentType: false,
                processData: false,
                data: data
            }).done(function (response) {
                abp.notify.success("StudentData saved Successfully");
                window.location.href = "/students"
            });
        }
    });
})();























//(function () {
//    var _studentService = abp.services.app.student;
//    var _$form = $('#StudentEditForm');
    //var stateId = $("#State");
    //var cityId = $("#City");

    //$("#Country").on("change", function () {
    //    var countryValue = $(this).val();
    //    _studentService.getStateComboboxDto(countryValue).done(function (responses) {
    //        if (responses != null) {
    //            stateId.find('option').remove();
    //            stateId.append("<option value=''>Select</option>");
    //            $.each(responses, function (index, item) {
    //                stateId.append($('<option/>', {
    //                    value: item.value,
    //                    text: item.displayText,
    //                    selected: item.isSelected ? true : false
    //                }));
    //            });
    //        }
    //    });

    //    $("#State").on("change", function () {
    //        var stateValue = $(this).val();
    //        _studentService.getCityComboboxDto(stateValue).done(function (responses) {
    //            if (responses != null) {
    //                cityId.find('option').remove();
    //                cityId.append("<option value=''>Select</option>");
    //                $.each(responses, function (index, item) {
    //                    cityId.append($('<option/>', {
    //                        value: item.value,
    //                        text: item.displayText,
    //                        selected: item.isSelected ? true : false
    //                    }));
    //                });
    //            }
    //        });
    //    });
    //})

//    $('#datepicker').datepicker({
//        format: 'mm/dd/yyyy',
//        autoclose: true,
//    });
//    debugger
//    $("#btnSave").click(function (e) {
//        if (!_$form.valid()) {
//            return;
//        }
//        debugger
//        var countrySelectId = $("#Country option:selected").val();
//        var stateSelectId = $("#State option:selected").val();
//        var citySelectId = $("#City option:selected").val();

//        var hobbyId = [];
//        $('.chkHobbies').each(function () {
//            var $this = $(this)
//            if ($this.prop("checked")) {
//                hobbyId.push($this.val());
//            }
//        });
//        var student = _$form.serializeFormToObject();
//        student.HobbiesIds = hobbyId;
//        student.CountryId = countrySelectId;
//        student.StateId = stateSelectId;
//        student.CityId = citySelectId;

//        _studentService.createOrUpdateStudent(student).done(function () {
//            abp.notify.success('Saved Sucessfully', 'Success')
//            window.location.href = "/students"
//        });
//    });
//})();