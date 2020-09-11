(function () {
    $(function () {
        var _orderService = abp.services.app.order;
        
        $('#CreateOrder').click(function () {
            window.location.href = "/Orders/CreateOrUpdateOrder"
        });

        function lineChartOrder() {
            $("#dialog").dialog({
                autoOpen: false,
                width: 600,
                height: 500,
                modal: true
            });

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
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: false
                        }
                    },
                    series: [{
                        name: "Items",
                        data: names
                    }]
                });
            });
            $('#dialog').dialog('open');
        }

        function editOrder(id) {
            if (id > 0) {
                window.location.href = "/Orders/CreateOrUpdateOrder?id=" + id;
            }
            else {
                window.location.href = "/Students/CreateOrUpdateOrder";
            }
        }
        function deleteOrder(id) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('Deleteorder', 'ITactDemo')),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _orderService.deleteorder({ id: id }).done(function () {
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                            jQuery(grid_selector).trigger("reloadGrid");
                        });
                    }
                }
            );
        }
        var grid_selector = "#order";
        var pager_selector = "#orderPager";
        var grid_url = "/Orders/GetOrder";
        jQuery(grid_selector).jqGrid({
            url: grid_url,
            sortname: "id",
            colNames: ["Order Number", "Order Date", "Description", "Total Amount", "Id", "Action"],
            colModel: [
                {
                    name: "orderNumber", index: "orderNumber", search: true, width: 20
                },
                {
                    name: "orderDate", index: "orderDate", search: true, width: 20, formatter: dateFormatter,
                    searchoptions: {
                        sopt: ['eq'],
                        dataInit: function (elem) {
                            $(elem).datepicker({
                                singleDatePicker: true,
                                autoclose: true,
                                showDropdowns: true,
                                autoUpdateInput: false
                            }).on('apply.datepicker', function (ev, picker) {
                                $(this).val(picker.startDate.format('L'));
                                $(this).keydown();
                            });
                        }
                    }
                },
                {
                    name: "description", index: "description", search: true, width: 100
                },
                {   
                    name: "totalAmount", index: "totalAmount", search: true, width: 20, formatter: priceFormat, align: 'right' 
                },
                {
                    name: "id", index: "id", hidden: true, key: true
                },
                {
                    name: 'actions', index: 'id', formatter: actionFormatter, sortable: false, width: 150, align: "center", search: false, width: 20
                }
            ],
            pager: pager_selector,
            height: "100%",
            width: "auto",
            viewrecords: true,
            multiselect: false,
            subGrid: true,
            
            subGridOptions: {
                "plusicon": "ui-icon-plus",
                "minusicon": "ui-icon-minus",
                "openicon": " ui-icon-arrowreturn-1-s",
                
            },
            
            subGridRowExpanded: function (subgrid_id, row_id) {
                var subgrid_table_id, pager_id;
                subgrid_table_id = subgrid_id + "_t";
                pager_id = "p_" + subgrid_table_id;
                $("#"+subgrid_id).html("<table id='" +subgrid_table_id+ "'></table><div id='" +pager_id+ "'></div>");
                jQuery("#"+subgrid_table_id).jqGrid({
                    url: "/Orders/GetOrderItems?id=" + row_id,
                    colNames: ['Item Name', 'Price'],
                    colModel: [
                        {
                            name: "itemName", index: "itemName", width: 50 
                        },
                        {
                            name: "price", index: "price", width: 50, align: 'right', formatter: priceFormat
                        }
                    ],
                    rowNum:10,
                    pager: pager_id,
                    height: "100%",
                    width: "100%",
                    loadComplete: function () {
                        
                        jQuery("#" + subgrid_table_id).trigger('resize');
                        $("#" + subgrid_table_id).jqGrid('setGridWidth', $("#" + subgrid_table_id).closest(".jqgrid").width());
                    },
                    
                });
                
                jQuery("#" + subgrid_table_id).navGrid(pager_id, jgridNavOpt);
            },
            
            
            loadComplete: function () {

                jQuery(grid_selector).trigger('resize');
                $(grid_selector).jqGrid('setGridWidth', $(grid_selector).closest(".jqgrid").width());

                $(grid_selector + ' .btnDelete').click(function () {

                    deleteOrder($(this).data().id);
                });

                $(grid_selector + ' .btnGraph').click(function () {
                    lineChartOrder();
                    
                });
                
                $(grid_selector + ' .btnEdit').click(function () {
                    editOrder($(this).data().id);
                });
            }
        });
        jQuery(grid_selector).navGrid(pager_selector, jgridNavOpt);
        jQuery(grid_selector).jqGrid('filterToolbar', jgridFilterOpt, { search: true, searchtext: "Search" });

    });

    function actionFormatter(cellvalue, options, rowObject) {
        
        var actions = "";
        actions += "<button class='btn btn-xs btn-success btnEdit' data-id='" + rowObject['id'] + " 'tooltip='Edit'><i class='fa fa-edit'></i></button>&nbsp; ";
        actions += "<button class='btn btn-xs btn-danger btnDelete' data-id='" + rowObject['id'] + "'tooltip='Delete'><i class='fa fa-remove'></i></button>&nbsp;";
        actions += "<button class='btn btn-xs btn-danger btnGraph' data-id='" + rowObject['id'] + "'tooltip='Get'><i class='fa fa-bars'></i></button>";
        return actions;
    }

    function dateFormatter(cellvalue, options, rowObject) {

        if (cellvalue !== null && cellvalue !== "") {

            return moment(cellvalue).format('L');
        }
        else {
            return "";
        }
    }

    function priceFormat(cellvalue, options, rowObject) {

        if (cellvalue !== null && cellvalue !== "") {
            return cellvalue.toFixed(2);
        }
    }
    function collapseAllRowsOfGrid(grid) {
        $(grid.allRows()).each(function (index, element) {
            $("#" + subgrid_table_id).igHierarchicalGrid("collapse", element);
        });
    }
    
    
})();