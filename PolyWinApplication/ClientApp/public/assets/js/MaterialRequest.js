
$.ajax({
    url: "PolyWinLogIn/GetParentCategorywithProductForWebApp",
    type: 'GET',
    beforeSend: function () {
        $('#loadingMaterial').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        for (let i = 0; i < result.payload.length; i++) {
            var cat_name = result.payload[i].parentCategory;
            if (cat_name.includes('/')) {
                cat_name = cat_name.replace('/', '');
            }
            var catnew = cat_name.replace(/ /g, "");
            if (i == 0) {
                $(".ulPvc").append("<li class='nav-item'><a  class='nav-link active' href = '#" + catnew + "' id='" + catnew + "-tab' data-toggle='tab'  role='tab' aria-controls='" + catnew + "' aria-selected='false'>" + cat_name + "</a></li>");
            } else {
                $(".ulPvc").append("<li class='nav-item'><a  class='nav-link' href = '#" + catnew + "' id='" + catnew + "-tab' data-toggle='tab'  role='tab' aria-controls='" + catnew + "' aria-selected='false'>" + cat_name + "</a></li>");
            }
            if (i == 0) {
                $(".picturesPvc").append("<div  class='tab-pane fade padding-30 active show'  id='" + catnew + "' role='tabpanel' aria-labelledby='" + catnew + "- tab'><div class='row  justify-content-end imgAppendPvc" + i + "'></div></div>");
            } else {
                $(".picturesPvc").append("<div  class='tab-pane fade padding-30'  id='" + catnew + "' role='tabpanel' aria-labelledby='" + catnew + "- tab'><div class='row  justify-content-end imgAppendPvc" + i + "'></div></div>");
            }
            for (let ii = 0; ii < result.payload[i].listCategory.length; ii++) {
                if (result.payload[i].listCategory[ii].products != null) {
                    for (let iii = 0; iii < result.payload[i].listCategory[ii].products.length; iii++) {
                        if (result.payload[i].listCategory[ii].products.length == 0) {
                            $(".imgAppendPvc" + i + "").append("<div class=-md-3'><h1>غير متوفر صور حاليا</h1></div>");
                        } else {
                            //$(".imgAppendPvc" + i + "").append("<div class='col-md-4'><div class='card cardForGallery' style='max-width: 20rem;'><img class='card-img-top cover' width='200' height='300' src ='" + result.payload[i].listCategory[ii].products[iii].imgURL + "' alt =" + result.payload[i].listCategory[ii].products[iii].name + " ><div class='card-body  text-white bg-dark p-2 .bodyForGallery'>" + result.payload[i].listCategory[ii].products[iii].productCode + "</div>");
                            $(".imgAppendPvc" + i + "").append("<div class='col-sm-3 boxAgent shadow-sm p-2 mb-4 bg-white rounded'><div class= 'card'><img class='imgAgent cover' src='" + result.payload[i].listCategory[ii].products[iii].imgURL + "' alt=" + result.payload[i].listCategory[ii].products[iii].name + "/> <div class='card-body'><h6 class='card-title margin-bottom-0'><span class='orgCol'>" + result.payload[i].listCategory[ii].products[iii].productCode + ":الكود</span></h6><p class='card-text colorHeadingBlue margin-bottom-0'>" + result.payload[i].listCategory[ii].products[iii].name + "</p><p class='card-text margin-bottom-0'><span class='orgCol'>" + result.payload[i].listCategory[ii].products[iii].pricePerOne + " : السعر بالعود </span></p><p class='orgCol'>" + result.payload[i].listCategory[ii].products[iii].pricePerMeter + " : السعر بالمتر</p></div></div></div >");
                        }
                    }
                }
            }
        }
    }, complete: function () {
        $("#loadingMaterial").css("visibility", "hidden");
        $("#MaterialSubMenu").removeClass("hidden");

    }
});



