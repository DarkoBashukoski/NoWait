let currentTime = new Date();

let selectedDate = null;
let dateButtons = []
let labels = []
let dates = []

$("#calendar-container button").each(function () {
    let b = $(this);
    dateButtons.push(b);
});

$("#calendar-container label").each(function () {
    labels.push($(this));
});

for (let i = 0; i < 6; i++) {
    currentTime = getNextDate(currentTime);
    dateButtons[i].html(currentTime.getDate());
    labels[i].text(getDayOfWeek(currentTime.getDay()));
    dates[i] = new Date(currentTime.getTime());

    dateButtons[i].click(function () {
        selectedDate = dateButtons[i];
        updateDateButtons();
        updateTimeButtons(dates[i], 1); //TODO change table number base on selected table
    });
}

function updateDateButtons() {
    dateButtons.forEach(b => {
        b.css("background-color", "white");
        b.css("color", " #198754");
        b.hover(function () {
            b.css("border", " #198754 solid 2px")
        }, function () {
            b.css("border", "lightgray solid 1px");
        });
    });
    selectedDate.css("background-color", " #198754");
    selectedDate.css("color", "white");
    selectedDate.css("border", " #198754 solid 2px");
    selectedDate.hover(function () {}, function () {});
}

function getNextDate(date) {
    let tomorrow = new Date(date.getTime());
    let day = date.getDate() + 1;

    if (day > new Date(date.getFullYear(), date.getMonth(), 0).getDate()) {
        tomorrow.setDate(1);
        if (date.getMonth() > 10) {
            tomorrow.setMonth(1);
            tomorrow.setFullYear(date.getFullYear() + 1);
        } else {
            tomorrow.setMonth(date.getMonth() + 1);
        }
    } else {
        tomorrow.setDate(day);
    }
    return tomorrow;
}

function getDayOfWeek(day) {
    switch (day) {
        case 0:
            return "Sun";
        case 1:
            return "Mon";
        case 2:
            return "Tue";
        case 3:
            return "Wed";
        case 4:
            return "Thu";
        case 5:
            return "Fri";
        case 6:
            return "Sat";
    }
}

function updateTimeButtons(date, tableId) {
    let timeContainer = $('#time-selection');
    let url = `/Reservation/GetAvailableReservations?year=${date.getFullYear()}&month=${date.getMonth()+1}&day=${date.getDate()}&tableId=${tableId}`

    $.get(url, function (data) {
        timeContainer.empty();
        data.forEach(element => {
            let AmPm = element <= 12 ? "AM" : "PM";
            let number = element % 12;
            number = number === 0 ? 12 : number;

            let html = '<div class="col-lg-6">'
            html += `<button class="btn btn-success">${number}:00 ${AmPm}</button>`
            html += '</div>'

            timeContainer.append(html);
        });
    });
}