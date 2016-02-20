function buttonOnClick(obj)
{
    var targetUrl = $(obj).attr("modal-url");

    $.ajax({
        url: targetUrl,
        method: "GET",
        success: function (data) {
            $('#modalcontent').html(data);
            $('#modalwindow').modal();
        },
        error: function ()
        {
            console.log('kurwa!');
        }
    });

}
//Metoda rozszerzajca HTML dziajca jak link, ale podmieniajca tresc modala

function ajaxSuccess(data)
{
    if (data.success)
    {
        $('#modal').hide();
    }
    else {
        $('#modal-container').html(data);
    }
}
// Ajax.BeginForm ktory w AjaxOptions(chyba 4 parametr) przyjmuje OnSuccess= "ajaxSuccess"