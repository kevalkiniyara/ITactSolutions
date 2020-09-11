(function () {
    var _studentModuleService = abp.services.app.studentModule;
    var stateId = $("#State");
    var cityId = $("#City");

    $("#Country").on("change", function () {

        var countryValue = $(this).val();
        _studentModuleService.getStateComboboxDto(countryValue).done(function (responses) {
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
            _studentModuleService.getCityComboboxDto(stateValue).done(function (responses) {
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
        
        if (!$('[name="StudentModuleForm"]').valid()) {
            return;
        }
        else {
            var _$Form = $('[name="StudentModuleForm"]').serializeFormDataToObject();
            var data = new FormData();
            
            data.append('Id', _$Form.Id);
            data.append('StudentName', _$Form.StudentName);
            data.append('Standard', _$Form.Standard);
            data.append('CountryId', _$Form.CountryId);
            data.append('StateId', _$Form.StateId);
            data.append('CityId', _$Form.CityId);
            data.append('Gender', _$Form.Gender);
            
            abp.ajax({
                url: '/StudentModules/CreateOrEditStudentModule',
                type: 'post',
                contentType: false,
                processData: false,
                data: data
            }).done(function (response) {
                
                abp.notify.success("saved Successfully");
            });
        }
    });
})();