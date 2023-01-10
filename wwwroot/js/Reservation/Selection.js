$(document).ready(function () {
    $('#menu-selection').css('height', window.innerHeight - 100)
    $(window).resize(function () {
        $('#menu-selection').css('height', window.innerHeight - 100)
    });
    $('#quantity-selection').css('height', window.innerHeight - 100)
    $(window).resize(function () {
        $('#quantity-selection').css('height', window.innerHeight - 100)
    });
});

function addToOrder(menuItemName, menuItemId) {
    let html = '<tr>'
    html += '<td class="itemName">' + menuItemName + '</td>'
    html += '<td><button id="add-' + menuItemId + '" class="btn btn-success"><i class="fa fa-plus"></i></button></td>'
    html += '<td class="itemCount" id="label-' + menuItemId + '">1</td>'
    html += '<td><button id="remove-' + menuItemId + '" class="btn btn-danger"><i class="fa fa-minus"></i></button></td>'
    html += '</tr>'

    $('#orders').append(html);
    $('#button-' + menuItemId).prop('disabled', true);
    $('#add-' + menuItemId).click(function () {
        let label = $('#label-' + menuItemId)
        let newValue = parseInt(label.html()) + 1;
        label.html(newValue);
    });
    $('#remove-' + menuItemId).click(function () {
        let label = $('#label-' + menuItemId)
        let newValue = parseInt(label.html()) - 1;
        if (newValue < 1) {
            $('#button-' + menuItemId).prop('disabled', false);
            label.closest('tr').remove();
        }

        label.html(newValue);
    });
}

function checkout() {
    let formData = new FormData();
    $("#orders tr").each(function () {
        let order = {
            menuItemName: $(this).find(".itemName").html(),
            count: $(this).find(".itemCount").html()
        }
        console.log(order);
        formData.append("orders", JSON.stringify(order))
    });
    $.ajax({
        url: "/Reservation/SubmitReservation/",
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function () {
            location.href = '/Home/Index/';
        }
    });
}