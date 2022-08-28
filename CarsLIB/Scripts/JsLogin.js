
function FunLoginCheck() {
    var username = $("#UseName").val();
    var password = $("#Password").val();
    $.ajax({
        type: "post",
        url: "/CarsInfo/Validate?Name=" + username,
        
        success: function (result) {
            if (result != null) {
                for (var i = 0; i < result[i].length; i++) {
                    if (result[i].Name == username && result[i].Password == password) {
                        window.location.href = "/CarsInfo/Index";
                    }
                    else {
                        $("#loginForm")[0].reset();
                        $("#Please Enter Correct Details.").show();
                        window.location.href = "CarsInfo/Login";
                        // $("#msg").hide();
                    }
                }
                return true;
            }
            else { return false;}
           
        }

    }); 

}