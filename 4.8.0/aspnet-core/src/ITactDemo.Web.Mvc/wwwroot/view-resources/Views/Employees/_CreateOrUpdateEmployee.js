(function () {

    var _employeeService = abp.services.app.employee;
    var stateId = $("#State");
    var cityId = $("#City");
    var itemId = $("#ItemId");
    var wrapper = $('.dynamic-items');
    var template = $('#itemTemplate', '#template');

    $('#Country').chosen({
         width: '200px' 
    });

    $("#Country").on("change", function () {
        var countryValue = $(this).val();
        _employeeService.getStateComboboxDto(countryValue).done(function (responses) {
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
            _employeeService.getCityComboboxDto(stateValue).done(function (responses) {
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

    $(document).on("click", ".add-item", function (e) {

        var newrow = null;
        newrow = template.clone().appendTo(wrapper);
        newrow.find("[name=Price]").val();
        $('.item', wrapper).each(function (idx) {
            $(this).find('td:first-child').html(idx + 1);
        });
    });
    
    $(document).on("change", "#Category", function () {
        debugger
        var $this = $(this);
        var category = $this.val();
        _employeeService.itemCombobox(category).done(function (response) {
            if (response != null) {
                var $item = $this.closest('tr').find('.items');
                $item.find('option').remove();
                $item.append("<option value=''>Select</option>");
                $.each(response, function (index, item) {
                    $item.append($('<option/>', {
                        value: item.value,
                        text: item.displayText,
                        selected: item.isSelected ? true : false
                    }));
                });
            }
        });
        $(document).on("change", "#ItemId", function () {
            var $this = $(this)
            var itemValue = $this.val();
            _employeeService.getItemPrice(itemValue).done(function (response) {
                if (response != null) {
                    var $price = $this.closest('tr').find('.price');
                    $price.val(response);
                }
            });
        });
    });

    $(wrapper).on("click", ".item .remove-item", function (e) {

        $(this).closest('tr').remove();

        $('.item', wrapper).each(function (idx) {
            $(this).find('td:first-child').html(idx + 1);
        });
    });
})();