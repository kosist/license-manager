$("#btn-edit-emergency-key").click(function () {
    $.ajax({
        url: "Products/EditEmergencyKey",
        type: "get",
        data: $("form").serialize(), //if you need to post Model data, use this
        success: function (result) {
            $("#emergencyKey").html(result);
        }
    });
})