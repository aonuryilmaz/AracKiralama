$(".dBtn").click(function (e) {
    e.preventDefault();
    var Id = $(this).data("id");
    $.ajax({
        url: "/Admin/Status/" + Id,
        method: "Post",
        success: function (data) {
            console.log(data);
            if (data) {
                $("#" + Id + "").removeClass("btn-danger");
                $("#" + Id + "").empty();
                $("#" + Id + "").text("True");
                $("#" + Id + "").addClass("btn-success");
            } else {
                $("#" + Id + "").removeClass("btn-success");
                $("#" + Id + "").empty();
                $("#" + Id + "").text("False");
                $("#" + Id + "").addClass("btn-danger");
            }
         
        }

    })
})