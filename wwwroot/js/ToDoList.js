
$(document).ready(function () {
    GetTodoList();
})

// Save Todo
$(".addBtn").click(function () {
        var task = new Object();
        task.Title = $("#myInput").val();
        $.ajax({
            type: "POST",
            url: "/ToDo/CreateTask",
            data: { 'task': task },
            success: function (response) {
                GetTodoList();
                $("#myInput").val("");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

//get Todo List
function GetTodoList() {
    $("#myTodoList").html("");
    $.ajax({
        type: "Get",
        url: "/ToDo/GetAllTasks",
        data: { },
        success: function (response) {
            var html = "";
            $(response.data).each(function () {
                html += "<li>" + this.title;
                html += '<span class="doneBtn" data-id="' + this.taskID + '">Done</span>';
                html +="</li>";
            })
            $("#myTodoList").append(html);

        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Mark as Done
$(document).on("click", ".doneBtn", function () {
    //get taskId
    var id = $(this).attr("data-id");

    //get current li
    var thisli = $(this).parent();
    $.ajax({
        type: "Post",
        url: "/ToDo/MarkAsCompleteTask",
        data: { "id": id},
        success: function (response) {
            if (response.status == "success") {
                //remove current li
                $(thisli).fadeOut(300, function () { $(thisli).remove(); });
                //$(thisli).hide('slow');
                //$(thisli).remove();
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
})