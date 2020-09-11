(function () {
    abp.ajax({
        url: '/Orders/GetItemData',
        type: 'get',
        contentType: false,
        processData: false,

    }).done(function (response) {
        
        var names = []
        var prices = []
        for (var i = 0; i < response.length; i++) {
            names.push(response[i].name);
            prices.push(response[i].price);
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
                categories: names
            },
            yAxis: {
                title: {
                    text: "Price"
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
                name: "Price",
                data: prices
            }]
        });
    });

   
})();
