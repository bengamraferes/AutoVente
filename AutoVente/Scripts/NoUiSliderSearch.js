var nonLinearSlider = document.getElementById('nonlinear');

noUiSlider.create(nonLinearSlider, {
    connect: true,
    behaviour: 'tap',
    start: [0,100000],
    range: {
        // Starting at 500, step the value by 500,
        // until 4000 is reached. From there, step by 1000.
        'min': [0],
        '10%': [100, 100],
        '50%': [25000, 100],
        'max': [100000]
    }
});
var inputNumber = document.getElementById('input-number');
var inputNumberMin = document.getElementById('input-numberMin');
nonLinearSlider.noUiSlider.on('update', function (values, handle) {

    var value = values[handle];

    if (handle) {
        inputNumber.value = Math.round(value);

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
//////////////////////////////////////////// Annee//////////
var nonLinearSliderAnnee = document.getElementById('nonlinearAnnee');

noUiSlider.create(nonLinearSliderAnnee, {
    connect: true,
    behaviour: 'tap',
    start: [1930, 2022],
    range: {
        // Starting at 500, step the value by 500,
        // until 4000 is reached. From there, step by 1000.
        'min': [1930],
        '10%': [1, 1],
        '50%': [2005, 1],
        'max': [2022]
    }
});
var inputNumberAnnee = document.getElementById('input-numberAnnee');
var inputNumberMinAnnee = document.getElementById('input-numberMinAnnee');
nonLinearSliderAnnee.noUiSlider.on('update', function (values, handle) {

    var value = values[handle];

    if (handle) {
        inputNumberAnnee.value = Math.round(value);

    } else {
        inputNumberMinAnnee.value = Math.round(value);
    }
});

inputNumberMinAnnee.addEventListener('change', function () {
    nonLinearSliderAnnee.noUiSlider.set([this.value, null]);
});

inputNumberAnnee.addEventListener('change', function () {
    nonLinearSliderAnnee.noUiSlider.set([null, this.value]);
});
//////////////////////////////////////////// Kilometrrage//////////
var nonLinearSliderKilometrrage = document.getElementById('nonlinearKilometrage');

noUiSlider.create(nonLinearSliderKilometrrage, {
    connect: true,
    behaviour: 'tap',
    start: [0, 350000],
    range: {
        // Starting at 500, step the value by 500,
        // until 4000 is reached. From there, step by 1000.
        'min': [0],
        '10%': [10000, 10000],
        '50%': [125000, 10000],
        'max': [350000]
    }
});
var inputNumberKilometrrage = document.getElementById('input-numberKilometrrage');
var inputNumberMinKilometrrage = document.getElementById('input-numberMinKilometrrage');
nonLinearSliderKilometrrage.noUiSlider.on('update', function (values, handle) {

    var value = values[handle];

    if (handle) {
        inputNumberKilometrrage.value = Math.round(value);

    } else {
        inputNumberMinKilometrrage.value = Math.round(value);
    }
});

inputNumberMinKilometrrage.addEventListener('change', function () {
    nonLinearSliderKilometrrage.noUiSlider.set([this.value, null]);
});

inputNumberKilometrrage.addEventListener('change', function () {
    nonLinearSliderKilometrrage.noUiSlider.set([null, this.value]);
});



   
 



