var myChart = $('#myChart');
function randomizeData() {
    config.data.datasets.forEach(function (dataset) {
        dataset.data.forEach(function (dataObj, j) {
            if (typeof dataObj === 'object') {
                dataObj.y = randomScalingFactor();
            } else {
                dataset.data[j] = randomScalingFactor();
            }
        });
    });

    myChart.update();
}

function addDataSet() {
    var colorName = colorNames[config.data.datasets.length % colorNames.length];
    var newColor = window.chartColors[colorName];
    var newDataset = {
        label: 'Dataset ' + config.data.datasets.length,
        borderColor: newColor,
        backgroundColor: color(newColor).alpha(0.5).rgbString(),
        data: []
    };

    for (var index = 0; index < config.data.labels.length; ++index) {
        newDataset.data.push(randomScalingFactor());
    }

    config.data.datasets.push(newDataset);
    myChart.update();
}

function addData() {
    if (config.data.datasets.length > 0) {
        config.data.labels.push(newDate(config.data.labels.length));

        for (var index = 0; index < config.data.datasets.length; ++index) {
            if (typeof config.data.datasets[index].data[0] === 'object') {
                config.data.datasets[index].data.push({
                    x: newDate(config.data.datasets[index].data.length),
                    y: randomScalingFactor()
                });
            } else {
                config.data.datasets[index].data.push(randomScalingFactor());
            }
        }

        myChart.update();
    }
}

function removeDataSet() {
    config.data.datasets.splice(0, 1);
    myChart.update();
}

function removeData() {
    config.data.labels.splice(-1, 1); // remove the label first

    config.data.datasets.forEach(function (dataset) {
        dataset.data.pop();
    });

    myChart.update();
}

function chartData(myChart, type, filters) {

    var config = {};
    var config = {
        type: 'line',
        data: {
            datasets: [
            {
                label: 'Dataset with string point data',
                backgroundColor: color(window.chartColors.red).alpha(0.5).rgbString(),
                borderColor: window.chartColors.red,
                fill: false,
                data: [
                    {
                        x: 0,
                        y: 0
                    }
                ]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Chart.js Time Point Data'
            },
            scales: {
                xAxes: [{
                    type: 'time',
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Date'
                    },
                    ticks: {
                        major: {
                            fontStyle: 'bold',
                            fontColor: '#FF0000'
                        }
                    }
                }],
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'value'
                    }
                }]
            }
        }
    };
}

$(document).ready(function () {

});