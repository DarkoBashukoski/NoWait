let selectedButton = null;
let currentTime = new Date();

buttons = []
labels = []

$("#calendar-container button").each(function () {
    let b = $(this);    
    buttons.push(b);
    b.click(function() {
        selectedButton = b;
        updateButtons();
    });
});

$("#calendar-container label").each(function () {
    labels.push($(this));
});

for (let i=0; i<6; i++) {
    buttons[i].html(currentTime.getDate());
    labels[i].text(getDayOfWeek(currentTime.getDay()));    
    currentTime = getNextDate(currentTime);
}

function updateButtons() {
    buttons.forEach(b => {
        b.css("background-color", "white");
        b.css("color", "green");
        b.css("border", "lightgray solid 1px")
    })
    selectedButton.css("background-color", "green");
    selectedButton.css("color", "white");
    selectedButton.css("border", "green double 2px")
}

function getNextDate(date) {
    let tomorrow = new Date(date.getTime());
    let day = date.getDate() + 1;
    
    if (day > new Date(date.getFullYear(), date.getMonth(), 0).getDate()) {
        tomorrow.setDate(1);
        if (date.getMonth() > 10) {tomorrow.setMonth(1); tomorrow.setFullYear(date.getFullYear() + 1);} 
        else {tomorrow.setMonth(date.getMonth() + 1);}
    } else {
        tomorrow.setDate(day);
    }
    return tomorrow;
}

function getDayOfWeek(day) {
    switch (day) {
        case 0: return "Mon";
        case 1: return "Tue";
        case 2: return "Wed";
        case 3: return "Thu";
        case 4: return "Fri";
        case 5: return "Sat";
        case 6: return "Sun";
    }
}