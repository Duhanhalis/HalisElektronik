var stickyMenu = document.querySelector(".he-position-absolute");
var sidebar = document.querySelector(".he-sidebar");
var iconSquare = document.querySelector(".icon-square img");

// Mobil İçin
if (window.screen.availWidth <= 426) {
    // Menü Düğmesi
    stickyMenu.addEventListener('click', function () {
        // Menü Dğümesi İçinde Active Yazıyor mu ?

        if (stickyMenu.classList.contains('active')) {
            sidebar.classList.add('active');
            stickyMenu.classList.remove('active');

            // Önceside Localstroage Yükle Pozisyonu
            localStorage.setItem('localscrolly', window.scrollY);

            // Yukari Gönder Kullanıcıyı
            window.scrollTo({
                left: 0,
                top: 0,
                behavior: "smooth"
            });
        }
    });

    // Kapata Düğümü
    iconSquare.addEventListener('click', function () {
        // localStorageden Çağır
        if (localStorage.getItem('localscrolly')) {
            // Varsa Geri Gönder
            window.scrollTo({
                left: 0,
                top: localStorage.getItem('localscrolly'),
                behavior: "smooth"
            })
        }
        sidebar.classList.remove('active');
        stickyMenu.classList.add('active');
    })
}