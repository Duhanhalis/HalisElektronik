// ? Tablet Moduna Geçince Href Attribute Kapanıyor Tıklama Yerini Alıyor.

var listItemhref = document.querySelectorAll('.header-list-item > a');
if (window.screen.availWidth < 1000) {
    listItemhref.forEach(element => {
        element.addEventListener('click', function () {
            element.removeAttribute('href')
        })
    });

}

var headerListItem = document.querySelectorAll('.header-list-group-sm >.header-list-item');

headerListItem.forEach(element => {
    if (element.children[1] != undefined) {
        if (element.children[1].className == 'header-list-item-group list-group') {
            element.addEventListener('click', function (e) {
                // console.log(element.children[1].classList.t);
                element.classList.toggle('dropdown-sm');
            })

        }
    }
})

var dropdown = document.querySelector('.header-empty');

dropdown.addEventListener('click', function (e) {

    var show = document.querySelector('.header-list-group-sm');
    show.classList.toggle('show');
})


