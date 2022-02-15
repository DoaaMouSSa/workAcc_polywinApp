var agent_id = window.location.search.substring(7);
$.ajax({
    url: "PolyWinLogIn/GetAgentById",
    type: "get",
    beforeSend: function () {
        $('#loadingCustomAgent').css("visibility", "visible");
    },
    data: {
        id: agent_id,
    },
    success: function (result) {
        $("#getAgentName").append(result.result.payload.name)
        var agentLogo = result.result.payload.agentLogo;
        var nameAgent = result.result.payload.nameAgent;
        var agentGovernorate = result.result.payload.agentGovernorate;
        var agentAddress = result.result.payload.agentAddress;
        var agentPhone = result.result.payload.agentPhone;
        var email = result.result.payload.email;
        var late = result.result.payload.Late;
        var long = result.result.payload.Long;
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
        if (late == null && long == null) {
           var noLocation  = "غير متوفر عنوان";
        }
        $("#agentName").append(nameAgent);
        $("#imgSelctor").append("<img   src='" + agentLogo + "' alt=" + nameAgent + " />");
        $("#infoSelctor").append("<h6 class='card-title margin-bottom-0'><span class='orgCol'>" + nameAgent + "</span></h6><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentAddress + "</p><p class='card-text margin-bottom-0'><span class='orgCol'>" + agentGovernorate + "</span></p><hr class='margin-0'><p class='card-text colorHeadingBlue margin-bottom-0'>" + agentPhone + "&nbsp&nbsp<i class='far fa-phone colorHeadingBlue'></i></p><p class='card-text colorHeadingBlue margin-bottom-0'>" + email + "&nbsp&nbsp<i class='far fa-envelope-open colorHeadingBlue'></i></p>");
        $("#GetAgentMap").append("<iframe class='responsive-iframe iframeCompany' scrolling = 'no'  src='https://maps.google.com/maps?q=" + late + ", " + long +"&hl=es&z=14&amp;output=embed'></iframe>");
    }, complete: function () {
        $("#loadingCustomAgent").css("visibility", "hidden");
    }

});

