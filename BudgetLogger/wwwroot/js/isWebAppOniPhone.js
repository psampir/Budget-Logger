// Function that checks whether the page is open as an iPhone web app

function isWebAppOniPhone() {
    return (window.navigator.standalone && /iPhone/.test(window.navigator.userAgent));
}

// If so, it changes max-height of the table to fit the screen better
if (isWebAppOniPhone()) {
    const divElement = document.querySelector('#x');
    if (divElement) {
        divElement.style.maxHeight = 'calc(100vh - 115px)';
    }
    else{
        alert("Web app detected on an iPhone!");
    }
}
