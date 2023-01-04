$(document).ready(function() {
    resizeImages();
    resizeCards();
    $(window).resize(resizeImages);
    $(window).resize(resizeCards);
});

function resizeImages() {
    $(".recipe-image").each(function() {
        $(this).css("height", $(this).width()*1.25);
    });
}

function resizeCards() {
    let maxHeight = 0;
    let card = $(".card")
    
    card.each(function() {
        $(this).css("height", "auto");
        maxHeight = $(this).height() > maxHeight ? $(this).height() : maxHeight;
    });
    card.each(function() {
        $(this).css("height", maxHeight + 32);
    });
}