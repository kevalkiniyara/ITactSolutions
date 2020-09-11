(function(){
    var _orderService = abp.services.app.order;
    var wrapper = $('.dynamic-items');
    var template = $('#itemTemplate', '#template');
    var itemId = $("#Item");

    $(document).on("click", ".add-item", function (e) {
        
        var newrow = null;
        newrow=template.clone().appendTo(wrapper);
        newrow.find("[name=Price]").val();
        $('.item', wrapper).each(function (idx) {
            $(this).find('td:first-child').html(idx + 1);
        });
    });

    $('#orderdatepicker').datepicker({
        format: "mm/dd/yyyy",
        autoclose: true,
        endDate: new Date()
    });
    
    $(document).on("change", "#Category", function () {
        $("#ordertable").loading('start');
        $('#ordertable').loading('stop');

        var $this = $(this);
        var category = $this.val();
        _orderService.itemCombobox(category).done(function (response) {
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
            _orderService.getItemPrice(itemValue).done(function (response) {
                
                if (response != null) {
                    var $price = $this.closest('tr').find('.price');
                    var number = numeral(response);
                    numeral.defaultFormat('0,0.00');
                    number.format();
                    $price.val(number.value().toFixed(2));
                }
            });
        });

        $(document).on("change", "#ItemId", function () {
            
            var $this = $(this)
            var itemValue = $this.val();
            _orderService.getItemImage(itemValue).done(function (response) {
                if (response != null) {
                    var $image = $this.closest('tr').find('.image');
                    $image.attr("src", '/' + response);
                    $image.attr("height", 100);
                    $image.attr("width", 100);

                    $image.val(response);
                }
            });
        });
    });

    $(document).on("click", "#btnCancel", function () {
        window.location.href = "/Orders"
    });
    
    $(document).on("click", "#btnSave", function (e) {

        if ($.trim($('#ItemId').val()) == '') {
            alert('please Select Item');
        }

        var _$form = $('[name=OrderForm]');
        if (!_$form.valid()) {
            return;
        }
        e.preventDefault();
        $("#orderData").hide();
        $("#imgloading").show();
        var order = _$form.serializeFormToObject();

        var itemPrice = 0;
        $('[name=Price]', wrapper).each(function (d) {
            var $thisVal = $(this).val();
            itemPrice += parseFloat($thisVal);
        });
        order.TotalAmount = itemPrice;

        order.OrderItems = [];
        $('.dynamic-items .item').each(function () {
            var orderItem = {};
            orderItem.Id = $(this).find('[name=Id]').val();
            orderItem.ItemId = $(this).find('[name=ItemId]').val();
            orderItem.price = $(this).find('[name=Price]').val();
            order.OrderItems.push(orderItem);
        });
        if (order.OrderItems.length > 0) {
            _orderService.createOrupdateOrder(order).done(function () {
                $("#imgloading").hide();
                abp.notify.success('Saved Sucessfully', 'Success')
                window.location.href = "/Orders"
            });
        }
    });

    $(wrapper).on("click", ".item .remove-item", function (e) {
        $(this).closest('tr').remove();
        
        $('.item', wrapper).each(function (idx) {
            $(this).find('td:first-child').html(idx + 1);
        });
    });

    function UpdateTotalCalculation() {
        var amount = 0;
        $('[name=Price]', wrapper).each(function (d) {
            var $this = $(this).val();
            amount += parseFloat($this);
        });
        $('.totalamount').html(Number(amount.toFixed(2)));
    }

    $(document).on("click", "#btnSaveSP", function (e) {
        var _$form = $('[name=OrderForm]');
        if (!_$form.valid()) {
            return;
        }
        e.preventDefault();
        
        var order = _$form.serializeFormToObject();

        var itemPrice = 0;
        $('[name=Price]', wrapper).each(function (d) {
            var $thisVal = $(this).val();
            itemPrice += parseFloat($thisVal);
        });
        order.TotalAmount = itemPrice;

        order.OrderItems = [];
        $('.dynamic-items .item').each(function () {
            var orderItem = {};
            orderItem.Id = $(this).find('[name=Id]').val();
            orderItem.ItemId = $(this).find('[name=ItemId]').val();
            orderItem.price = $(this).find('[name=Price]').val();
            order.OrderItems.push(orderItem);
        });
        if (order.OrderItems.length > 0) {
            _orderService.createJsonOrder(order).done(function () {
               
                abp.notify.success('Saved Sucessfully', 'Success')
                window.location.href = "/Orders"
            });
        }
    });
})();
