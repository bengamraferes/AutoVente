var colorPicker = document.getElementById('ColorPicker');

colorPicker.addEventListener("input", function () {
    document.getElementById('CodeCouleurFix').value = colorPicker.value;
})