var nonLinearSlider = document.getElementById('nonlinear');

noUiSlider.create(nonLinearSlider, {
    connect: true,
    behaviour: 'tap',
    start: [10, 40],
    range: {
        // Starting at 500, step the value by 500,
        // until 4000 is reached. From there, step by 1000.
        'min': [0],
        '10%': [5, 5],
        '50%': [50, 100],
        'max': [100]
    }
});
var inputNumber = document.getElementById('input-number');
var inputNumberMin = document.getElementById('input-numberMin');
nonLinearSlider.noUiSlider.on('update', function (values, handle) {

    var value = values[handle];

    if (handle) {
        inputNumber.value = value;

    } else {
        inputNumberMin.value = Math.round(value);
    }
});

inputNumberMin.addEventListener('change', function () {
    nonLinearSlider.noUiSlider.set([this.value, null]);
});

inputNumber.addEventListener('change', function () {
    nonLinearSlider.noUiSlider.set([null, this.value]);
});