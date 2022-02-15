
$.ajax({
    url: "api/Factoring/GetAllFactor",
    type: 'GET',
    beforeSend: function () {
        $('#loadingFactor').css("display", "block");
    },
    dataType: 'json',
    success: function (result) {
        console.log(result.payload);
        for (let i = 0; i < result.payload.length; i++) {
            //$("#divAllFactor").append("<div class='col-md-4'></div><div class='col-md-4'><div class= 'container' style ='text-align:center'><h3 style='color: #29abe2'>" + result.payload[i].description + "</h3><img style='border:4px solid #e6f5fc;width:100%;height:300px' src=" + result.payload[i].logoPath + " alt=''><a href=" + result.payload[i].filePath + " class='btn btn-info' style='margin-top:10px;' target='_blank'>تحميل الملف</a></div></div><div class='col-md-4'></div>");
            //$('#divAllFactor').append("<div class='col-md-4'></div><div class='col-md-4' style='margin-bottom:30px;'><div class='card' style='width:18rem;margin:0 auto;'><img class='card-img-top coverFitImg' style='height:250px;' src='" + result.payload[0].logoPath + "' alt=" + result.payload[0].description + "><div class='card-body' style='text-align:center;'><h3 class='card-title' style='color:#f37024;'>" + result.payload[0].description + "</h3><a target='_blank' href='" + result.payload[0].filePath + "' class='btn btn-primary'>تحميل الملف</a></div></div></div><div class='col-md-4'></div>");
            $('#divAllFactor').append("<div class='col-sm-3 boxCat blueDiv'><div class= 'card cardAgent blueDiv'><img class='imgAgent'  src='" + result.payload[i].logoPath + "' alt=" + result.payload[i].description + "/><div class='card-body'><h6 class='card-title whiteText'>" + result.payload[i].description + "</h6><p class='card-text whiteText'>يمكنك تحميل ملف التخصيمات من هنا</p><a target='_blank' href='" + result.payload[i].filePath + "' class='btn btn-primary orgBackBtn'>تحميل&nbsp&nbsp<i class='far fa-file-pdf'></i></a></div></div ></div>");
        }
    }, complete: function () {
        $("#loadingFactor").css("display", "none");
    }
});

