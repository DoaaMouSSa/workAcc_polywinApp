
var agent_id;
$.ajax({
    url: "api/Agent/GetAllAgents",
    type: 'GET',
    beforeSend: function () {
        $('#loadingAllAgents').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (result) {
        //console.log(result);
        for (let i = 0; i < result.payload.length; i++) {
            var agent_id = result.payload[i].id;
            var agentLogo = result.payload[i].agentLogo;
            var nameAgent = result.payload[i].nameAgent;
            var agentAddress = result.payload.agentAddress;
            var agentPhone = result.payload.agentPhone;
            var email = result.payload.email;
            var late = result.payload.Late;
            var long =result.payload.Long;
            var agentGovernorate=result.payload[i].agentGovernorate;
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
            //$("#divAllAgent").append("<div class='col-md-3 overFooterIcons hand' style='margin-bottom:30px;z-index:10;hand'><div onclick='getAgent_id(" + agent_id + ")' class='card mx-auto overFooterIcons' style='width:100%;margin:0 auto;height:220;text-align:center;hand'><img class='imgAgent'  src='" + agentLogo + "' alt=" + nameAgent + "><div class='card-body' style='text-align:center;'><h5 class='card-title' style='color:#f37024;'>" + nameAgent + "</h5><h5 style='color: #2ebdee;' class='card-text'>" + agentGovernorate + "</h5></div></div></div>");
            $("#ForAllAgents").append("<div class='col-sm-3 boxAgent shadow-sm p-2 mb-4 bg-white rounded'><div class= 'card cardAgent'><img class='imgAgent hand' onclick='getAgent_id(" + agent_id + ")' src='" + agentLogo + "' alt=" + nameAgent + "/> <div class='card-body'><h6 class='card-title margin-bottom-0'><span class='orgCol'>" + nameAgent + "</span></h6><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentAddress + "</p><p class='card-text margin-bottom-0'><span class='orgCol'>" + agentGovernorate + "</span></p><hr class='margin-0'><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentPhone + "&nbsp&nbsp<i class='far fa-phone colorHeadingBlue'></i></p><p class='card-text colorHeadingBlue margin-bottom-0'>" + email + "&nbsp&nbsp<i class='far fa-envelope-open colorHeadingBlue'></i></p><p class='card-text margin-bottom-0 hand orgCol' data-toggle='modal' data-target='#exampleModal" + i + "'> الموقع على الخريطه&nbsp&nbsp<i class='far fa-map-marker-alt orgCol'></i></p><div class='modal fade' id='exampleModal" + i + "' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'><div class= 'modal-dialog' role = 'document' ><div class='modal-content'><div class='modal-header'><h5 class='modal-title text-center orgCol' id='exampleModalLabel'>" + nameAgent + "</h5><button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div><div class='modal-body'><div class='map-area'><div class='map-wrapper'><iframe class='responsive-iframe iframeCompany' src='https://maps.google.com/maps?q=" + late + ", " + long + "&hl=es&z=14&amp;output=embed' allowfullscreen='' loading='lazy'></iframe></div></div></div></div></div ></div ></div></div></div >");
           //$("#divAllAgent").append("<div class='col-md-3'><div onclick='getAgent_id(" + agent_id + ")'  style='text-align:center;border-radius:10px;margin-bottom:6px;padding:20px;border:1px solid #f37024;text-align:center;cursor:pointer'><img style='width:100px;height:100px;' src=" + result.payload[i].agentLogo + "><br><h5 style = 'color:#f37024'>" + result.payload[i].nameAgent + "</h5><h6 style = 'color: #29abe2;'>" + result.payload[i].agentGovernorate + "</h6></div></div>");
            //$("#Slide").slick('slickAdd', "<div><img class='imgForSlickAgent' src=" + result.payload[i].agentLogo+"></div>");
        }
    }, complete: function () {
        $("#loadingAllAgents").css("visibility", "hidden");
    }
});

function getAgent_id(id) {
    agent_id = id;
    window.open("/agent.html?agent=" + agent_id)
}

