$("#btn-edit-emergency-key").click(function () {
    $.ajax({
        url: "Products/EditEmergencyKey/1",
        type: "get",
        contentType: "json",
        success: function (result) {
            $("#emergencyKey").html(result);
        }
    });
})