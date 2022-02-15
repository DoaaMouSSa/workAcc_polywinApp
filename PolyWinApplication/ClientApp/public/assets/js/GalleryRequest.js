
$.ajax({
    url: "PolyWinLogIn/GetAllCategoryGallery",
    type: 'GET',
    beforeSend: function () {
        $('#loadingSubG').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        console.log(result)
        for (let i = 0; i < result.payload.length; i++) {
        var cat_name = result.payload[i].name;
            if (cat_name.includes('/')) {
                cat_name = cat_name.replace('/', '');
            }
            var catnew = cat_name.replace(/ /g, "");
            if (i == 0) {
                $(".ulGallery").append("<li class='nav-item'><a  class='nav-link active' href = '#" + catnew + "' id='" + catnew + "-tab' data-toggle='tab'  role='tab' aria-controls='" + catnew + "' aria-selected='false'>" + cat_name + "</a></li>");
            } else {
                $(".ulGallery").append("<li class='nav-item'><a  class='nav-link' href = '#" + catnew + "' id='" + catnew + "-tab' data-toggle='tab'  role='tab' aria-controls='" + catnew + "' aria-selected='false'>" + cat_name + "</a></li>");
            }
            if (i == 0) {
                $(".ulGalleryMainPage").append("<li class='nav-item'><a  class='nav-link orgLink active' href = '#" + catnew + "' id='" + catnew + "-tab' data-toggle='tab'  role='tab' aria-controls='" + catnew + "' aria-selected='false'>" + cat_name + "</a></li>");
            } else {
                $(".ulGalleryMainPage").append("<li class='nav-item'><a  class='nav-link orgLink' href = '#" + catnew + "' id='" + catnew + "-tab' data-toggle='tab'  role='tab' aria-controls='" + catnew + "' aria-selected='false'>" + cat_name + "</a></li>");
            }
            if (i == 0) {
                $(".pictures").append("<div  class='tab-pane fade padding-30 active show'  id='" + catnew + "' role='tabpanel' aria-labelledby='" + catnew + "- tab'><div class='row justify-content-end imgAppend" + i + "'></div></div>");
            } else {
                $(".pictures").append("<div  class='tab-pane fade padding-30'  id='" + catnew + "' role='tabpanel' aria-labelledby='" + catnew + "- tab'><div class='row justify-content-end imgAppend" + i + "'></div></div>");
            }
            if (i == 0) {
                $(".picturesMainPage").append("<div  class='tab-pane fade padding-30 active show'  id='" + catnew + "' role='tabpanel' aria-labelledby='" + catnew + "- tab'><div class='row  justify-content-end imgAppendMainPage" + i + "'></div></div>");
            } else {
                $(".picturesMainPage").append("<div  class='tab-pane fade padding-30'  id='" + catnew + "' role='tabpanel' aria-labelledby='" + catnew + "- tab'><div class='row  justify-content-end imgAppendMainPage" + i + "'></div></div>");
            }
            for (let ii = 0; ii < result.payload[i].listGallery.length; ii++) {
                for (let iii = 0; iii < result.payload[i].listGallery[ii].gallery.length; iii++) {
                    if (result.payload[i].listGallery[ii].length < 1) {
                        alert(iii);
                        $(".imgAppend"+ i +"").append("<div class=-md-3'><h1>غير متوفر صور حاليا</h1></div>");
                    } else {
                        $(".imgAppend" + i + "").append("<div class='col-md-4'><div class='card cardForGallery' style='max-width: 20rem;'><img class='card-img-top cover' width='200' height='300' src ='" + result.payload[i].listGallery[ii].gallery[iii].pathImage + "' alt =" + result.payload[i].listGallery[ii].gallery[iii].description + " ><div class='card-body  text-white bg-dark p-2 .bodyForGallery'>" + result.payload[i].listGallery[ii].gallery[iii].description + "</div>");
                        $(".imgAppendMainPage" + i + "").append("<div class='col-md-3 padding-0'><div class='card cardForGallery noborder padding-0' style='max-width: 20rem;'><img class='card-img cover' width='200' height='300' src ='" + result.payload[i].listGallery[ii].gallery[iii].pathImage + "' alt =" + result.payload[i].listGallery[ii].gallery[iii].description + " ><div class='card-img-overlay  h-100 d-flex flex-column justify-content-end'><h4 class='card-title  text-white'>"+result.payload[i].listGallery[ii].gallery[iii].description+"</h4></div>");
                    }
                }
            }
        }
    }, complete: function () {
        $("#loadingSubG").css("visibility", "hidden");
        $("#GallerySubMenu").removeClass("hidden");
        
    }
});


