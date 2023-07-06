function previewImage() {
    var fileInput = document.getElementById('imageFileUpload');
    var previewImage = document.getElementById('preview');

    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            previewImage.src = e.target.result;
            previewImage.style.display = 'block';
        };

        reader.readAsDataURL(fileInput.files[0]);
    }
}
