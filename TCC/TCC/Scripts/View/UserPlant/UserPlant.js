window.chartColors = { "red": "rgb(255, 99, 132)", "orange": "rgb(255, 159, 64)", "yellow": "rgb(255, 205, 86)", "green": "rgb(75, 192, 192)", "blue": "rgb(54, 162, 235)", "purple": "rgb(153, 102, 255)", "grey": "rgb(201, 203, 207)" }
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

function chartData() {
    var randomScalingFactor = function () {
        return Math.ceil(Math.random() * 10.0) * Math.pow(10, Math.ceil(Math.random() * 5));
    };
    var labels = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30'];
    var myChart = $('#Chart');
    var config = {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Consumo Medio',
                    backgroundColor: window.chartColors.red,
                    borderColor: window.chartColors.red,
                    fill: false,
                    data: [
                        2,
                        4,
                        6,
                        8,
                        10,
                        20,
                        30
                    ]
                },
                {
                    label: 'Seu Consumo',
                    backgroundColor: window.chartColors.blue,
                    borderColor: window.chartColors.blue,
                    fill: false,
                    data: [
                        2,
                        4,
                        6,
                        9,
                        12,
                        15,
                        18,
                        20,
                        23,
                        27,
                        30
                    ]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Consumo de Agua'
            },
            scales: {
                xAxes: [{
                    display: true,
                    title: 'Dias',
                    text: 'Dias'
                }],
                yAxes: [{
                    display: true,
                    title: 'Consumo',
                    text: 'Consumo'
                }]
            }
        }
    };

    myChart = new Chart(myChart, config);
}

$(document).ready(function () {
    chartData();
});