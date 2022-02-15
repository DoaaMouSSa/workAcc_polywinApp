
var ImgLst;
var VidLst;
$.ajax({
    url: "PolyWinLogIn/GetClientOpinions",
    type: 'GET',
    beforeSend: function () {
        $('#loadingOp').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        console.log(result.payload);
        for (let i = 0; i < result.payload.length; i++) {
            var p = result.payload[i];
            if ((result.payload[i].comment != null && result.payload[i].imgPath != null && p.vidPath != null) || p.imgPath != null && p.vidPath != null) {
                $("#divAllComm").append("<div class='col-sm-3'><div class= 'card oddCard marginForClientCard shadow-sm p-2 mb-4 bg-white rounded'><img class='card-img-top imgComment' src='" + p.imgPath + "' alt=Client/><div class='card-body'><h6 class='card-title margin-bottom-0 text-center oddCardtext '>" + p.comment + "</h6></div></div></div >");
                $("#divAllComm").append("<div class='col-sm-3'><div class= 'card evenCard marginForClientCard shadow-sm p-2 mb-4 bg-white rounded'><video class='card-img-top vidComment'  controls><source src=" + p.vidPath + " type ='video/mp4'><a class='nav-link popup-video play-btn-style' href=" + p.vidPath + "></a></video><div class='card-body'><h6 class='card-title margin-bottom-0 text-center evenCardtext '>" + p.comment + "</h6></div></div></div >");
            }
            if (p.vidPath != null && p.imgPath == null) {
                $("#divAllComm").append("<div class='col-sm-3'><div class= 'card evenCard marginForClientCard shadow-sm p-2 mb-4 bg-white rounded'><video class='card-img-top vidComment'  controls><source src='" + p.vidPath + "' type ='video/mp4'><a class='nav-link popup-video play-btn-style' href=" + p.vidPath + "></a></video><div class='card-body'><h6 class='card-title margin-bottom-0 text-center evenCardtext '>" + p.comment + "</h6></div></div></div >");
            }
            if (p.vidPath == null && p.imgPath != null) {
                $("#divAllComm").append("<div class='col-sm-3'><div class= 'card oddCard marginForClientCard shadow-sm p-2 mb-4 bg-white rounded'><img class='card-img-top imgComment' src='" + p.imgPath + "' alt=Client/><div class='card-body'><h6 class='card-title margin-bottom-0 text-center oddCardtext '>" + p.comment + "</h6></div></div></div >");
            }
        }
    }, complete: function () {
        $("#loadingOp").css("visibility", "hidden");
    }
});


