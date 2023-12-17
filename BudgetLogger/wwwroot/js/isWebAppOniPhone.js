// Function that checks whether the page is open as an iPhone web app
function isWebAppOniPhone() {
    return (window.navigator.standalone && /iPhone/.test(window.navigator.userAgent));
}

// If so, it changes max-height of the table to 100vh - 105px
if (isWebAppOniPhone()) {
    const divElement = document.querySelector('.table-responsive.table-responsive-sm');
    if (divElement) {
        divElement.style.maxHeight = 'calc(100vh - 105px)';
    }
}