var pagination = document.querySelector('.pagination');

var productLength = 100;
var page = 20;
var httpProtocol = window.location.href;

function paginationLength(prLength, page) {
    var split = (prLength / page).toFixed();

    // Sayfalama da Geri Git Denemek
    var http = httpProtocol.slice(httpProtocol.lastIndexOf('/')+1, httpProtocol.length);
    
    pagination.innerHTML = `<li class="page-item">
        <a class="page-link" href="" aria-label="Previous">
            <span aria-hidden="true">&laquo;</span>
        </a>
    </li>`;


    for (let index = 1; index <= split; index++) {
        // Url de Kaçıncı sayfada onu bul eğer varsa
        if (http.includes(`/${index}`)) {
            pagination.innerHTML += `<li class="page-item active"><a class="page-link" href="${httpProtocol}/${index}">${index}</a></li>`
        }
        else {

            pagination.innerHTML += `<li class="page-item"><a class="page-link" href="${httpProtocol}/${index}">${index}</a></li>`
        }
    }

    pagination.innerHTML += `<li class="page-item">
        <a class="page-link" href="#" aria-label="Next">
            <span aria-hidden="true">&raquo;</span>
        </a>
    </li>`;
}
paginationLength(productLength, page);


// Id den alir data-length den uzunluk degerini alir.
var text = document.querySelectorAll('#textClip');

function textClip(document, textLength) {
    if (textLength == null) {
        textLength = 25;
    }
    if (document.innerHTML.length >= textLength) {
        document.innerHTML = `${document.textContent.slice(0, textLength)}...`;
    }
}
text.forEach(e => {
    textClip(e, e.getAttribute('data-length'));
})

// 