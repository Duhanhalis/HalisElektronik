
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