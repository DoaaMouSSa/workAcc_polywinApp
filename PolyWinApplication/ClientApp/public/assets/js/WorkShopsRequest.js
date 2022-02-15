$(document).on('click', 'input[type="checkbox"]', function () {
    $('input[type="checkbox"]').not(this).prop('checked', false);
});
function getAll() {
    $.ajax({
        url: "PolyWinLogIn/GetAllWorkShopsByGov",
        type: 'GET',
        beforeSend: function () {
            $('#loadingGov').css("visibility", "visible");
        },
        dataType: 'json',
        success: function (result) {
            $("#allWorkShops").empty();
            $("#getGovs").empty();
            $("#getGovs").append("<div class='checkbox hand'><label class='orgCol' onclick='getAll(); '>الكل<input onclick='getAll(); ' type='checkbox' checked /> </label></div>");
            for (let i = 0; i < result.result.payload.length; i++) {
                $("#getGovs").append("<div class='checkbox hand'><label class='orgCol' onclick='Filter(this.innerText);'>" + result.result.payload[i].agentGovernorate + "<input onclick='Filter(this.value);' value=" + result.result.payload[i].agentGovernorate + " type='checkbox' id='" + i + "' /></label></div>");
                for (let ii = 0; ii < result.result.payload[i].listAgent.length; ii++) {
                    var agent_id = result.result.payload[i].listAgent[ii].id;
                    var agentLogo = result.result.payload[i].listAgent[ii].agentLogo;
                    var nameAgent = result.result.payload[i].listAgent[ii].nameAgent;
                    var agentAddress = result.result.payload[i].listAgent[ii].agentAddress;
                    var agentPhone = result.result.payload[i].listAgent[ii].agentPhone;
                    var email = result.result.payload[i].listAgent[ii].email;
                    var late = result.result.payload[i].listAgent[ii].Late;
                    var long = result.result.payload[i].listAgent[ii].Long;
                    var agentGovernorate = result.result.payload[i].agentGovernorate;
                    if (agentLogo == null) {
                        agentLogo = "";
                    }
                    if (nameAgent == null) {
                        nameAgent = "غير متوفر اسم";
                    }
                    if (agentGovernorate == null) {
                        agentGovernorate = "غير متوفر محافظه";
                    }
                    if (agentAddress == null) {
                        agentAddress = "غير متوفر عنوان";
                    }
                    if (agentPhone == null) {
                        agentPhone = "غير متوفر رقم تليفون";
                    }
                    if (email == null) {
                        email = "غير متوفر بريد الكترونى";
                    }
                    if (late == null || long == null) {

                    }
                    $("#allWorkShops").append("<div class='col-sm-4 boxAgent shadow-sm p-2 mb-4 bg-white rounded'><div class= 'card cardAgent'><img class='imgAgent hand' onclick='getAgent_id(" + agent_id + ")' src='" + agentLogo + "' alt=" + nameAgent + "/> <div class='card-body'><h6 class='card-title margin-bottom-0'><span class='orgCol'>" + nameAgent + "</span></h6><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentAddress + "</p><p class='card-text margin-bottom-0'><span class='orgCol'>" + agentGovernorate + "</span></p><hr class='margin-0'><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentPhone + "&nbsp&nbsp<i class='far fa-phone colorHeadingBlue'></i></p><p class='card-text colorHeadingBlue margin-bottom-0'>" + email + "&nbsp&nbsp<i class='far fa-envelope-open colorHeadingBlue'></i></p><p class='card-text margin-bottom-0 hand orgCol' data-toggle='modal' data-target='#exampleModal" + i + "'>شاهد الموقع على الخريطه&nbsp&nbsp<i class='far fa-map-marker-alt orgCol'></i></p><div class='modal fade' id='exampleModal" + i + "' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'><div class= 'modal-dialog' role = 'document' ><div class='modal-content'><div class='modal-header'><h5 class='modal-title text-center orgCol' id='exampleModalLabel'>" + nameAgent + "</h5><button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div><div class='modal-body'><div class='map-area'><div class='map-wrapper'><iframe class='responsive-iframe iframeCompany' src='https://maps.google.com/maps?q=" + late + ", " + long + "&hl=es&z=14&amp;output=embed' allowfullscreen='' loading='lazy'></iframe></div></div></div></div></div ></div ></div></div></div >");
                }
            };
        }, complete: function () {
            $("#loadingGov").css("visibility", "hidden");
        }
    });
    $(document).on('click', 'input[type="checkbox"]', function () {
        $('input[type="checkbox"]').not(this).prop('checked', false);
    });
}
getAll();
function getAgent_id(id) {
    agent_id = id;
    window.open("/agent.html?agent=" + agent_id)
}
/************************getworkshopsByOnlyOneGovernment********************************/
function Filter(name) {
    $.ajax({
        url: "PolyWinLogIn/GetWorkShopByOneGov",
        type: 'get',
        beforeSend: function () {
            $('#loadingGov').css("visibility", "visible");
        }, data: {
            Govname: name,
        },
        success: function (result) {
            $("#allWorkShops").empty();
                for (let i = 0; i < result.result.payload.length; i++) {
                        var agent_id = result.result.payload[i].id;
                        var agentLogo = result.result.payload[i].agentLogo;
                        var nameAgent = result.result.payload[i].nameAgent;
                        var agentAddress = result.result.payload[i].agentAddress;
                        var agentPhone = result.result.payload[i].agentPhone;
                        var email = result.result.payload[i].email;
                        var late = result.result.payload[i].Late;
                        var long = result.result.payload[i].Long;
                    var agentGovernorate = result.result.payload[i].agentGovernorate;
                        if (agentLogo == null) {
                            agentLogo = "";
                        }
                        if (nameAgent == null) {
                            nameAgent = "غير متوفر اسم";
                        }
                        if (agentGovernorate == null) {
                            agentGovernorate = "غير متوفر محافظه";
                        }
                        if (agentAddress == null) {
                            agentAddress = "غير متوفر عنوان";
                        }
                        if (agentPhone == null) {
                            agentPhone = "غير متوفر رقم تليفون";
                        }
                        if (email == null) {
                            email = "غير متوفر بريد الكترونى";
                        }
                        if (late == null || long == null) {

                        }
                        $("#allWorkShops").append("<div class='col-sm-4 boxAgent shadow-sm p-2 mb-4 bg-white rounded'><div class= 'card cardAgent'><img class='imgAgent hand' onclick='getAgent_id(" + agent_id + ")' src='" + agentLogo + "' alt=" + nameAgent + "/> <div class='card-body'><h6 class='card-title margin-bottom-0'><span class='orgCol'>" + nameAgent + "</span></h6><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentAddress + "</p><p class='card-text margin-bottom-0'><span class='orgCol'>" + agentGovernorate + "</span></p><hr class='margin-0'><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentPhone + "&nbsp&nbsp<i class='far fa-phone colorHeadingBlue'></i></p><p class='card-text colorHeadingBlue margin-bottom-0'>" + email + "&nbsp&nbsp<i class='far fa-envelope-open colorHeadingBlue'></i></p><p class='card-text margin-bottom-0 hand orgCol' data-toggle='modal' data-target='#exampleModal" + i + "'>شاهد الموقع على الخريطه&nbsp&nbsp<i class='far fa-map-marker-alt orgCol'></i></p><div class='modal fade' id='exampleModal" + i + "' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'><div class= 'modal-dialog' role = 'document' ><div class='modal-content'><div class='modal-header'><h5 class='modal-title text-center orgCol' id='exampleModalLabel'>" + nameAgent + "</h5><button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div><div class='modal-body'><div class='map-area'><div class='map-wrapper'><iframe class='responsive-iframe iframeCompany' src='https://maps.google.com/maps?q=" + late + ", " + long + "&hl=es&z=14&amp;output=embed' allowfullscreen='' loading='lazy'></iframe></div></div></div></div></div ></div ></div></div></div >");
                    }
                
        }, complete: function () {
            $("#loadingGov").css("visibility", "hidden");
        }
    });
}

