

//main menu animacije
var cards = document.querySelectorAll('.card');

for (var i = 0; i < cards.length; i++) {
    cards[i].addEventListener('click', function () {
        for (var j = 0; j < cards.length; j++) {
            if (this != cards[j]) {
                var x = cards[j].querySelector(".card-header a");
                var y = cards[j].querySelector(".card .collapse");
                if (x != null && y != null) {
                    x.setAttribute("aria-expanded", "false");
                    x.setAttribute("class", "d-block collapsed");
                    y.setAttribute("class", "collapse");
                }
            }
        }
    })
}

// disable enter to submit form
$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});


