
$.ajax({
    url: "api/CompanyInfo/GetCompanyInfo",
    type: 'GET',
    beforeSend: function () {
        $('#loadingAboutComp').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        //console.log(result.payload);
        //$("#divAllInfo").append("<div class='col-md-4'></div><div class='col-md-8'><div class= 'container arabic' style ='text-align:right;'><h3 style='color: #29abe2'>رؤية الشركه :" + result.payload.companyInfo + "</h3><br/><h3 style='color: #29abe2'>رسالة الشركه : " + result.payload.futureInfo + "</h3><a href=" + result.payload.companyFile + " class='btn btn-info hand' style='margin-top:10px;' target='_blank'>تحميل الملف</a></div></div>");
        $(".infoSum").append(result.payload.companyInfo);
        $('.futureInfo').append(result.payload.futureInfo);
        $('#CompanyFile').attr("href", result.payload.companyFile);
        //$("#infoDet").append(result.payload.futureInfo);
        
    }, complete: function () {
        $("#loadingAboutComp").css("visibility", "hidden");
    }
});

