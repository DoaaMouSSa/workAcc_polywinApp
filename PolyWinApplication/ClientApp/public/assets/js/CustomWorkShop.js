var GovName;

function getGovName(name) {
    console.log(name)
    window.open('/WorkShop.html?name=' + name);
}
GovName = window.location.search.substring(6);

$.ajax({
    url: "PolyWinLogIn/GetAllWorkShopsByGov",
    type: 'GET',
    beforeSend: function () {
        $('#loadingWorkShopByGov').css("visibility", "visible");
    },
    dataType: 'json',
    success: function (data) {
        //console.log(data.result.payload)
        var Gotdata = data.result.payload;
        console.log(Gotdata)
        for (let i = 0; i < Gotdata.length; i++) {
            if (Gotdata[i].agentGovernorate == GovName) {
                $("#getGovName").append(GovName);
                for (let ii = 0; ii < Gotdata[i].listAgent.length; ii++) {
                    var workshop_id = Gotdata[i].listAgent[ii].id;
                   var latitude = Gotdata[i].listAgent[ii].late;
                    var longtiude = Gotdata[i].listAgent[ii].long;
                    var name = Gotdata[i].listAgent[ii].nameAgent;
                    var email = Gotdata[i].listAgent[ii].email;
                    
                    if (email == null) {
                        email = "غير متوفر بريد الكترونى";
                    }
                    //$("#CustomWorkShop").append("<div class='col-md-4'><div style='padding:8px;border:1px solid #fdd7bb;text-align:center;margin:10px'><img style='width:100px;height:100px;' src=" + Gotdata[i].listAgent[ii].agentLogo + "><h5 style='color: #2ebdee;'>" + Gotdata[i].listAgent[ii].nameAgent + "</h5><h5 style='color: #2ebdee;'>" + Gotdata[i].listAgent[ii].agentPhone + "</h5><h5 style='color: #2ebdee;'>" + Gotdata[i].listAgent[ii].email + "</h5><h5 style='color: #2ebdee;'>" + Gotdata[i].listAgent[ii].agentAddress + "</h5></div></div>")
                    $("#CustomWorkShop").append("<div class='col-md-4 overFooterIcons hand' onclick='getAgent_id(" + workshop_id + ")'><div class= 'card' style = 'width:18rem;margin:0 auto;margin-bottom:30px;'><img class='card-img-top coverFitImg' style='height:250px;' src=" + Gotdata[i].listAgent[ii].agentLogo + " alt=" + name + "><div class='card-body' style='text-align:center;'><h3 class='card-title' style='color:#f37024;'>" + Gotdata[i].listAgent[ii].nameAgent + "</h3><h5 style='color: #2ebdee;' class='card-text'>" + Gotdata[i].listAgent[ii].agentPhone + "</h5><h5 class='card-text' style='color: #2ebdee;'>" + email + "</h5><h5 class='card-text' style='color: #2ebdee;'>" + Gotdata[i].listAgent[ii].agentAddress + "</h5></div></div></div>");
                }
                return;
            }
        }
    }, complete: function () {
        $("#loadingWorkShopByGov").css("visibility", "hidden");
    }
});
function getAgent_id(id) {
    agent_id = id;
    window.open("/agent.html?agent=" + agent_id)
}

