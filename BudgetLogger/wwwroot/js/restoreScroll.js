const path = window.location.pathname;
const list = path.split('/');
const cookieName = list.filter(n => n).pop();

window.addEventListener('load', function () {
    const position = getCookie(cookieName);

    if (position !== undefined) {
        setTimeout(function () {
            console.log(`restore scroll position - ${position}`);
            window.scrollTo({
                top: position,
                left: 0,
                behavior: 'smooth',
            });
        }, 1);
    }
});

let timerId;

window.addEventListener('scroll', function () {
    if (timerId) {
        clearTimeout(timerId);
    }

    timerId = setTimeout(function () {
        const position = window.pageYOffset;
        console.log(`set scroll cookie - ${position}`);
        setCookie(cookieName, position, {secure: true, 'max-age': 'session'});
    }, 300);
});