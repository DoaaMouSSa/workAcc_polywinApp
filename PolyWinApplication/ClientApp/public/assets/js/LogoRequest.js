
$.ajax({
    url: "api/Agent/GetAllAgents",
    type: 'GET',
    beforeSend: function () {
        $('#loadingCarousel').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        for (let i = 0; i < result.payload.length; i++) {
            $("#Slide").slick('slickAdd',"<div class='col-xl-12'><div class='brand-img text-center'><img class='cover' width='80' height='80' src=" + result.payload[i].agentLogo + " /></div></div>");
          }
    }, complete: function () {
        $("#loadingCarousel").css("visibility", "hidden");
    }
});
$.ajax({
    url: "PolyWinLogIn/GetClientOpinions",
    type: 'GET',
    beforeSend: function () {
        $('#loadingCarousel').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        for (let i = 0; i < result.payload.length; i++) {
            if ((result.payload[i].comment != null && result.payload[i].imgPath != null && result.payload[i].vidPath != null) || result.payload[i].imgPath != null && result.payload[i].vidPath != null) {
                $("#SlideClinets").slick('slickAdd', "<div class='col-xl-12'><div class='brand-img text-center'><img class='contain' width='80' height='80' src=" + result.payload[i].imgPath + " /><p class='blueText'>" + result.payload[i].comment+"</p></div></div>");
                }
        }
    }, complete: function () {
        $("#loadingCarousel").css("visibility", "hidden");
    }
});

