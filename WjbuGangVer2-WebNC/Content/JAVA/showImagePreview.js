function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function ShowImagePreview1(imageUploader1, previewImage1) {
    if (imageUploader1.files && imageUploader1.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage1).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader1.files[0]);
    }
}

function ShowImagePreview2(imageUploader2, previewImage2) {
    if (imageUploader2.files && imageUploader2.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage2).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader2.files[0]);
    }
}

function ShowImagePreview3(imageUploader3, previewImage3) {
    if (imageUploader3.files && imageUploader3.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage3).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader3.files[0]);
    }
}

function ShowImagePreview4(imageUploader4, previewImage4) {
    if (imageUploader4.files && imageUploader4.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage4).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader4.files[0]);
    }
}