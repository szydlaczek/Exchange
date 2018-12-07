$(document).ready(function () { 

    $('body').on('click', '.purchase', function (evt) {
        var id = $(evt.target).closest("tr").attr("data-id");
        $.ajax({
            data: { currencyId: id },
            url: "/Application/ShowPurchaseForm"
        }).done(function (data) {
            $("body").append(data);
            $("#modal-window").toggleClass("modal-fade-in"); 
        }).fail()        
    });
    $('body').on('click', '.sell', function (evt) {
        var id = $(evt.target).closest("tr").attr("data-id");
        $.ajax({
            data: { currencyId: id },
            url: "/Application/ShowSellForm"
        }).done(function (data) {
            $("body").append(data);
            $("#modal-window").toggleClass("modal-fade-in");
        }).fail()
    });
    $('body').on('click', '.close-modal', function (evt) {
        closeForm();
    });
});
var closeForm = function () {
    $("#modal-window").remove();
}
    