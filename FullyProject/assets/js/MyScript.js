/*
function AddPropertyState()
{
    $("#modelTitle").html("أضافة حالة عقار");
    
    $("#label").html("حالة العقار");
}


function Add()
    {
    var name = $("#name").val();
    $.ajax({
        type: "Post",
        url: "AddPropertyState",
        data: name,
        success: function (r) {
            if (r) {
                $('#default').modal("hide");
                
                window.location.href = "Create";

            }
        }
    })
    }

    */
function UpdateToRead()
{
    var id=$("#mId").val();
    $.ajax(
        {
            type: "Get",
            url: "ChangeToRead?id=" + id,
            success: function (r) {
                if (r) {
                    alert("Successed Delete");
                    
                }
            }
        })
}
