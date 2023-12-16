// Sprawdzenie, czy strona jest otwarta jako aplikacja internetowa na iPhone'ie
function isWebAppOniPhone() {
    return (window.navigator.standalone && /iPhone/.test(window.navigator.userAgent));
}

// Jeśli strona jest otwarta jako aplikacja internetowa na iPhone'ie, zmień max-height na 105px
if (isWebAppOniPhone()) {
    const divElement = document.querySelector('.table-responsive.table-responsive-sm');
    if (divElement) {
        divElement.style.maxHeight = 'calc(100vh - 105px)';
    }
}
