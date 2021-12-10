var colorPicker = document.QuerySelector('#ColorPicker');

colorPicker.addEventListener('change', (event) => {
    var val = colorPicker.value;
    document.QuerySelector('#CodeCouleurFix').value = val;
})