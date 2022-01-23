$.get("http://" + window.location.hostname + ":" + window.location.port+"/api/Insight/", function (data) {
    var Script = function () {
        console.log(data)
        //morris chart

        $(function () {
            // data stolen from http://howmanyleft.co.uk/vehicle/jaguar_'e'_type
            //var tax_data = [
            //    { "period": "2011 Q3", "licensed": 3407, "sorned": 660 },
            //    { "period": "2011 Q2", "licensed": 3351, "sorned": 629 },
            //    { "period": "2011 Q1", "licensed": 3269, "sorned": 618 },
            //    { "period": "2010 Q4", "licensed": 3246, "sorned": 661 },
            //    { "period": "2009 Q4", "licensed": 3171, "sorned": 676 },
            //    { "period": "2008 Q4", "licensed": 3155, "sorned": 681 },
            //    { "period": "2007 Q4", "licensed": 3226, "sorned": 620 },
            //    { "period": "2006 Q4", "licensed": 3245, "sorned": null },
            //    { "period": "2005 Q4", "licensed": 3289, "sorned": null }
            //];
            //Morris.Line({
            //    element: 'hero-graph',
            //    data: tax_data,
            //    xkey: 'period',
            //    ykeys: ['licensed', 'sorned'],
            //    labels: ['Licensed', 'Off the road'],
            //    lineColors: ['#4ECDC4', '#ed5565']
            //});

            Morris.Donut({
                element: 'origine-donut',
                data: data.origines,
                colors: ['#3498db', '#2980b9', '#34495e','#62809e'],
                formatter: function (y) { return y + "%" }
            });
            Morris.Donut({
                element: 'type-donut',
                data: data.types,
                colors: ['#3498db', '#2980b9', '#34495e','#62809e'],
                formatter: function (y) { return y + "%" }
            });
            Morris.Donut({
                element: 'carburent-donut',
                data: data.carburents,
                colors: ['#3498db', '#2980b9', '#34495e', '#62809e'],
                formatter: function (y) { return y + "%" }
            });
            //get the pie chart canvas
            var ctx1 = $("#pie");
          
            var boiteVitesses = data.boiteVitesses;
            //pie chart data
            var data1 = {
                labels: [boiteVitesses[0].label, boiteVitesses[1].label],
                datasets: [
                    {
                        label: "TeamA Score",
                        data: [boiteVitesses[0].value, boiteVitesses[1].value],
                        backgroundColor: [
                            "#3498db",
                            "#34495e",
                           
                        ],
                        borderColor: [
                            "#ffffff",
                            "#ffffff",
                          
                        ],
                        borderWidth: [2, 2]
                    }
                ]
            };

         

            //options
            var options = {
                responsive: false,
                title: {
                    display: true,
                    position: "top",
                    text: "Pie Chart",
                    fontSize: 18,
                    fontColor: "#111"
                },
                legend: {
                    display: true,
                    position: "bottom",
                    labels: {
                        fontColor: "#333",
                        fontSize: 16
                    }
                }
            };

            //create Chart class object
            var chart1 = new Chart(ctx1, {
                type: "pie",
                data: data1,
                options: options
            });

          
            
            //Morris.Area({
            //    element: 'hero-area',
            //    data: [
            //        { period: '2010 Q1', iphone: 2666, ipad: null, itouch: 2647 },
            //        { period: '2010 Q2', iphone: 2778, ipad: 2294, itouch: 2441 },
            //        { period: '2010 Q3', iphone: 4912, ipad: 1969, itouch: 2501 },
            //        { period: '2010 Q4', iphone: 3767, ipad: 3597, itouch: 5689 },
            //        { period: '2011 Q1', iphone: 6810, ipad: 1914, itouch: 2293 },
            //        { period: '2011 Q2', iphone: 5670, ipad: 4293, itouch: 1881 },
            //        { period: '2011 Q3', iphone: 4820, ipad: 3795, itouch: 1588 },
            //        { period: '2011 Q4', iphone: 15073, ipad: 5967, itouch: 5175 },
            //        { period: '2012 Q1', iphone: 10687, ipad: 4460, itouch: 2028 },
            //        { period: '2012 Q2', iphone: 8432, ipad: 5713, itouch: 1791 }
            //    ],

            //    xkey: 'period',
            //    ykeys: ['iphone', 'ipad', 'itouch'],
            //    labels: ['iPhone', 'iPad', 'iPod Touch'],
            //    hideHover: 'auto',
            //    lineWidth: 1,
            //    pointSize: 5,
            //    lineColors: ['#4a8bc2', '#ff6c60', '#a9d86e'],
            //    fillOpacity: 0.5,
            //    smooth: true
            //});

            //Morris.Bar({
            //    element: 'hero-bar',
            //    data: [
            //        { device: 'iPhone', geekbench: 136 },
            //        { device: 'iPhone 3G', geekbench: 137 },
            //        { device: 'iPhone 3GS', geekbench: 275 },
            //        { device: 'iPhone 4', geekbench: 380 },
            //        { device: 'iPhone 4S', geekbench: 655 },
            //        { device: 'iPhone 5', geekbench: 1571 }
            //    ],
            //    xkey: 'Date',
            //    ykeys: ['chiffreAffaire'],
            //    labels: ['Geekbench'],
            //    barRatio: 0.4,
            //    xLabelAngle: 35,
            //    hideHover: 'auto',
            //    barColors: ['#ac92ec']
            //});

            //new Morris.Line({
            //    element: 'examplefirst',
            //    xkey: 'year',
            //    ykeys: ['value'],
            //    labels: ['Value'],
            //    data: [
            //        { year: '2008', value: 20 },
            //        { year: '2009', value: 10 },
            //        { year: '2010', value: 5 },
            //        { year: '2011', value: 5 },
            //        { year: '2012', value: 20 }
            //    ]
            //});

            $('.code-example').each(function (index, el) {
                eval($(el).text());
            });
        });

    }();
});






