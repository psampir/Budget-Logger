// Function that checks whether the page is open as an iPhone web app
function isWebAppOniPhone() {
    return (window.navigator.standalone && /iPhone/.test(window.navigator.userAgent));
}

// If so, it changes max-height of the table to fit the screen better
if (isWebAppOniPhone()) {
    const divElementX = document.querySelector('#x');
    const divElementY = document.querySelector('#y');
    if (divElementX) {
        divElementX.style.maxHeight = 'calc(100vh - 115px)';
    }
    else if (divElementY) {
        divElementY.style.maxHeight = 'calc(61vh - 115px)';
    }
    else{
        alert("Web app detected on an iPhone!");
    }
}
