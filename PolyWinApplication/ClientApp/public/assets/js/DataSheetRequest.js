
$.ajax({
    url: "PolyWinLogIn/GetAllCatalogue",
    type: 'GET',
    beforeSend: function () {
        $('#loading').css("display", "block");
    },
    dataType: 'json',
    success: function (result) {
        console.log(result.payload);
        for (let i = 0; i < result.payload.length; i++) {
            $("#divAllCatalogue").append("<div class='col-md-4'><div class= 'container' style ='text-align:center;margin-bottom:5px;'><h3 style='color: #29abe2'>" + result.payload[i].description + "</h3><img style='border:1px solid #e6f5fc;width:100%;height:300px' src=" + result.payload[i].logoPath + " alt=''><a href=" + result.payload[i].filePath + " class='btn btn-info' style='margin-top:10px;' target='_blank'>تحميل الملف</a></div></div>");
                         
        }
    }, complete: function () {
        $("#loading").css("display", "none");
    }
});

