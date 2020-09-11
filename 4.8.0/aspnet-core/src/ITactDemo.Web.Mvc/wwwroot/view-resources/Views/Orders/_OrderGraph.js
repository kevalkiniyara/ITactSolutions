(function () {

    abp.ajax({
        url: '/Orders/GetOrderData',
        type: 'get',
        contentType: false,
        processData: false,
        
    }).done(function (response) {
        
        var names = []
        var orderNumber = []
        for (var i = 0; i < response.length; i++) {
            names.push(response[i].item);
            orderNumber.push(response[i].orderNumber);
        }
        Highcharts.chart('container', {
            chart: {
                type: 'line'
            },
            title: {
                text: 'Order-Items'
            },
            subtitle: {
                text: 'Line-Graph'
            },
            xAxis: {
                categories: orderNumber
            },
            yAxis: {
                title: {
                    text: "Quantity"
                }
            },
            
            plotOptions: {
                series: {
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                                OrderItem(this.category);
                            }
                        }
                    }
                }
            },
            series: [{
                name: "Items",
                data: names
            }]
        });
        });
    
    function OrderItem(category) {

        $("#dialog").dialog({
            autoOpen: false,
            width: 365,
            height: 210,
            modal: false
        });

        var grid_selector = "#item";
        var pager_selector = "#itemPager";
        var grid_url = "/Orders/GetOrderValue?orderNumber=" +category;

        jQuery(grid_selector).jqGrid({
            url: grid_url,
            sortname: "id",
            colNames: ["Item Name", "Price"],
            colModel: [
                {
                    name: "itemName", index: "itemName", width: 50
                },
                {
                    name: "price", index: "price", width: 25, align: 'right', formatter: priceFormat
                },
            ],
            pager: pager_selector,
            height: "auto",
            width: "auto",

            loadComplete: function () {

                jQuery(grid_selector).trigger('resize');
                $(grid_selector).jqGrid('setGridWidth', $(grid_selector).closest(".jqgrid1").width());
            }
        });
        jQuery(grid_selector).navGrid(pager_selector, jgridNavOpt);

        function priceFormat(cellvalue, options, rowObject) {

            if (cellvalue !== null && cellvalue !== "") {
                return cellvalue.toFixed(2);
            }
        }
        $('#dialog').dialog('open');
    }
    
})();
